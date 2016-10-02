package com.insorama.insoramapp;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class SignupScreen extends AppCompatActivity {
    EditText keyNoEdit;
    EditText clientEdit;
    Button signUp;
    Button cancel;

    static boolean isOn = false;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_signup_screen);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        keyNoEdit = (EditText) findViewById(R.id.signup_screen_key_number);
        clientEdit = (EditText) findViewById(R.id.signup_screen_client_id);
        signUp = (Button) findViewById(R.id.signup_screen_signup);
        cancel = (Button) findViewById(R.id.signup_screen_back);
        isOn = true;

        signUp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String keyNumber = keyNoEdit.getText().toString();
                String clientId = clientEdit.getText().toString();
                SoapRequestManager requestManager = new SoapRequestManager(clientId, keyNumber);
                requestManager.signUp();
            }
        });

        cancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                isOn = false;
                finish();
            }
        });


    }

    @Override
    protected void onResume() {
        super.onResume();
        isOn = true;
    }

    @Override
    protected void onStart() {
        super.onStart();
        isOn = true;
    }

    static void loginHandler(boolean canLogIn, String keyNumber, String clientId) {
        Context context = SplashScreen.splashScreenContext;
        if (canLogIn) {
            SharedPreferences prefs = SplashScreen.splashScreenContext.getSharedPreferences(Constants.Prefs.MY_PREFS, MODE_PRIVATE);
            SharedPreferences.Editor edit = prefs.edit();
            edit.putString(Constants.Prefs.KEY_NUMBER, keyNumber);
            edit.putString(Constants.Prefs.CLIENT_ID, clientId);
            edit.apply();
            isOn = false;
            context.startActivity(new Intent(context, MainScreen.class));
        } else {
            Toast.makeText(context, "Τα στοιχεία που δώσατε δεν βρέθηκαν. Προσπαθήστε ξανά.", Toast.LENGTH_LONG).show();
            if (!isOn) {
                context.startActivity(new Intent(context, SignupScreen.class));
            }
        }
    }

}
