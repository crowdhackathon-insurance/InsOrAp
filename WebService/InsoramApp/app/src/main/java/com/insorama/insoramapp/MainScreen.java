package com.insorama.insoramapp;

import android.Manifest;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

public class MainScreen extends AppCompatActivity {

    Button settings;
    Button accident;
    Button theft;
    Button fire;
    Button shatter;

    SharedPreferences prefs;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_screen);

        prefs = getSharedPreferences(Constants.Prefs.MY_PREFS, MODE_PRIVATE);
        String clientId = prefs.getString(Constants.Prefs.CLIENT_ID, null);
        String keyNo = prefs.getString(Constants.Prefs.KEY_NUMBER, null);

        if (clientId != null && keyNo != null) {
            SoapRequestManager requestManager = new SoapRequestManager(clientId, keyNo);
            requestManager.getCarList();
        } else {
            Toast.makeText(this, "Υπήρξε λάθος στην σύνδεση.", Toast.LENGTH_LONG).show();
            startActivity(new Intent(this, SignupScreen.class));
        }

        settings = (Button) findViewById(R.id.main_screen_settings);
        accident = (Button) findViewById(R.id.main_screen_accident);
        theft = (Button) findViewById(R.id.main_screen_theft);
        fire = (Button) findViewById(R.id.main_screen_fire);
        shatter = (Button) findViewById(R.id.main_screen_shatter);

        settings.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(MainScreen.this, SettingsScreen.class));
            }
        });

        accident.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(MainScreen.this, AccidentScreen.class));
            }
        });

        theft.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //startActivity(new Intent(MainScreen.this, TheftScreen.class));
            }
        });

        fire.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //startActivity(new Intent(MainScreen.this, FireScreen.class));
            }
        });

        shatter.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //startActivity(new Intent(MainScreen.this, ShatterScreen.class));
            }
        });

    }

    @Override
    protected void onStart() {
        super.onStart();
        int GPSPermission = ContextCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION);
        int callPermission = ContextCompat.checkSelfPermission(this, Manifest.permission.CALL_PHONE);

        if (GPSPermission != PackageManager.PERMISSION_GRANTED) {
            requestGPSPermission();
        }

        if (callPermission != PackageManager.PERMISSION_GRANTED) {
            requestCallPermission();
        }
    }

    private void requestGPSPermission() {
        ActivityCompat.requestPermissions(this,
                new String[] {Manifest.permission.ACCESS_FINE_LOCATION}, 0);
    }

    private void requestCallPermission() {
        ActivityCompat.requestPermissions(this,
                new String[] {Manifest.permission.CALL_PHONE}, 0);
    }


}
