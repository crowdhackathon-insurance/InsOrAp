package com.insorama.insoramapp;


import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;


public class FragmentEmergencyCalls extends Fragment {

    Button callPolice;
    Button callAmbulance;
    Button callInsurance;
    Button callMe;


    public FragmentEmergencyCalls() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_emergency_calls, container, false);

        callPolice = (Button) view.findViewById(R.id.emergency_calls_police);
        callAmbulance = (Button) view.findViewById(R.id.emergency_calls_ambulance);
        callInsurance = (Button) view.findViewById(R.id.emergency_calls_insurance_call);
        callMe = (Button) view.findViewById(R.id.emergency_calls_call_me);

        callPolice.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent policeIntent = new Intent(Intent.ACTION_CALL, Uri.parse("tel:100"));
                startActivity(policeIntent);
            }
        });

        callAmbulance.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String number = Constants.Prefs.AMBULANCE_NUMBER;
                Uri call = Uri.parse("tel:" + number);
                Intent ambulanceIntent = new Intent(Intent.ACTION_CALL, call);
                startActivity(ambulanceIntent);
            }
        });

        callInsurance.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String number = Constants.Prefs.INSURANCE_NUMBER;
                Uri call = Uri.parse("tel:" + number);
                Intent insuranceIntent = new Intent(Intent.ACTION_CALL, call);
                startActivity(insuranceIntent);
            }
        });

        callMe.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                SharedPreferences prefs = getActivity().getSharedPreferences(Constants.Prefs.MY_PREFS, Context.MODE_PRIVATE);
                String clientId = prefs.getString(Constants.Prefs.CLIENT_ID, "");
                String keyNumber = prefs.getString(Constants.Prefs.KEY_NUMBER, "");
                SoapRequestManager requestManager = new SoapRequestManager(clientId, keyNumber);
                //TODO: Find confused usages of keyNumber and contractNumber
                //TODO: Create askForCall();
                //requestManager.askForCall();
            }
        });


        return view;
    }

}
