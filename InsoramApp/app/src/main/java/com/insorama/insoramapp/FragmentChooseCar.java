package com.insorama.insoramapp;


import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;

import java.util.List;


public class FragmentChooseCar extends Fragment {

    Spinner carChoiceSpinner;
    Button next;
    Button cancel;

    String[] contractNumbers;

    public FragmentChooseCar() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_choose_car, container, false);

        carChoiceSpinner = (Spinner) view.findViewById(R.id.choose_car_spinner); //TODO: Double check this
        next = (Button) view.findViewById(R.id.choose_car_next);
        cancel = (Button) view.findViewById(R.id.choose_car_cancel);

        next.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                FragmentManager fragmentManager = getFragmentManager();
                FragmentTransaction transaction = fragmentManager.beginTransaction();

                String selectedContractNumber = contractNumbers[carChoiceSpinner.getSelectedItemPosition()];


                SharedPreferences prefs = getActivity().getSharedPreferences(Constants.Prefs.MY_PREFS, Context.MODE_PRIVATE);
                SharedPreferences.Editor editor = prefs.edit();

                editor.putString(Constants.Prefs.CONTRACT_NUMBER, selectedContractNumber);
                editor.apply();


                transaction.add(R.id.fragment_container, AccidentScreen.fragmentCheckBoxes);
                transaction.addToBackStack(null);
                transaction.commit();
            }
        });

        cancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                getActivity().finish();
            }
        });

        return view;
    }

    @Override
    public void onStart() {
        super.onStart();
        List<CarInfo> carInfos = AccidentScreen.dbManager.getAllCars();
        String[] adapterString = new String[carInfos.size()];
        contractNumbers = new String[carInfos.size()];

        int i = 0;
        for (CarInfo c : carInfos) {
            if (!c.getFriendlyName().equals("")) {
                adapterString[i] = c.getFriendlyName() + "-" + c.getLicensePlate();
            } else {
                adapterString[i] = c.getLicensePlate();
            }
            contractNumbers[i] = c.getContractNumber();
            i++;
        }

        ArrayAdapter<String> adapter = new ArrayAdapter<>(AccidentScreen.accidentContext,
                android.R.layout.simple_spinner_dropdown_item, adapterString);

        carChoiceSpinner.setAdapter(adapter);
    }

}
