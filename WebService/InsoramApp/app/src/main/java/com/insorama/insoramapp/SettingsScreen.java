package com.insorama.insoramapp;

import android.provider.ContactsContract;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import java.util.List;

public class SettingsScreen extends AppCompatActivity {

    Spinner spinner;
    Button declare;
    Button complete;
    Button delete;
    EditText friendlyName;
    DataBaseManager dbManager;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_settings_screen);

        spinner = (Spinner) findViewById(R.id.settings_spinner);
        declare = (Button) findViewById(R.id.settings_car_declare_btn);
        complete = (Button) findViewById(R.id.settings_complete);
        delete = (Button) findViewById(R.id.settings_delete_all);
        friendlyName = (EditText) findViewById(R.id.settings_friendly_name);

        dbManager = new DataBaseManager(this);

        declare.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String friendly = friendlyName.getText().toString();
                if (!friendly.equals("")) {
                    friendlyName.setText("");
                    String contractNo = spinner.getSelectedItem().toString().split("~")[1];
                    if (dbManager.replaceValue(friendly, contractNo)) {
                        Toast.makeText(SettingsScreen.this, "Το όνομα αποθηκεύτηκε", Toast.LENGTH_LONG).show();
                    } else {
                        Toast.makeText(SettingsScreen.this, "Υπήρξε κάποιο πρόβλημα στην αποθήκευση. " +
                                "Παρακαλώ προσπαθήστε ξανά", Toast.LENGTH_LONG).show();
                    }
                } else {
                    Toast.makeText(SettingsScreen.this, "Πρέπει να δηλώσετε όνομα για το αυτοκίνητό σας", Toast.LENGTH_LONG).show();
                }
            }
        });

        complete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });


    }

    @Override
    protected void onResume() {
        super.onResume();

        List<CarInfo> cars = dbManager.getAllCars();
        String[] stringAdapter = new String[cars.size()];

        int i = 0;
        for (CarInfo c : cars) {
            stringAdapter[i] = c.getLicensePlate() + "~" + c.getContractNumber();
            i++;
        }

        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_dropdown_item, stringAdapter);
        spinner.setAdapter(adapter);
    }
}
