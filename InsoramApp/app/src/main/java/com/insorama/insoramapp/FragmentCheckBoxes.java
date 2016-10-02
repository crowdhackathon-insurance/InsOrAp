package com.insorama.insoramapp;


import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.LinearLayout;


/**
 * A simple {@link Fragment} subclass.
 */
public class FragmentCheckBoxes extends Fragment {

    LinearLayout police;
    LinearLayout ambulance;
    LinearLayout law;
    LinearLayout breakdown;
    LinearLayout blame;

    static CheckBox policeCheck;
    static CheckBox ambulanceCheck;
    static CheckBox lawCheck;
    static CheckBox breakdownCheck;
    static CheckBox blameCheck;

    Button next;
    Button previous;


    public FragmentCheckBoxes() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_check_boxes, container, false);

        police = (LinearLayout) view.findViewById(R.id.checkboxes_police);
        policeCheck = (CheckBox) view.findViewById(R.id.checkboxes_police_check);

        ambulance = (LinearLayout) view.findViewById(R.id.checkboxes_ambulance);
        ambulanceCheck = (CheckBox) view.findViewById(R.id.checkboxes_ambulance_check);

        law = (LinearLayout) view.findViewById(R.id.checkboxes_law);
        lawCheck = (CheckBox) view.findViewById(R.id.checkboxes_law_check);

        breakdown = (LinearLayout) view.findViewById(R.id.checkboxes_breakdown);
        breakdownCheck = (CheckBox) view.findViewById(R.id.checkboxes_breakdown_check);

        blame = (LinearLayout) view.findViewById(R.id.checkboxes_blame);
        blameCheck = (CheckBox) view.findViewById(R.id.checkboxes_blame_check);

        next = (Button) view.findViewById(R.id.checkboxes_next);
        previous = (Button) view.findViewById(R.id.checkboxes_previous);



        police.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!policeCheck.isChecked()) {
                    policeCheck.setChecked(true);
                } else {
                    policeCheck.setChecked(false);
                }
            }
        });

        ambulance.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!ambulanceCheck.isChecked()) {
                    ambulanceCheck.setChecked(true);
                } else {
                    ambulanceCheck.setChecked(false);
                }
            }
        });

        law.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (lawCheck.isEnabled()) {
                    if (!lawCheck.isChecked()) {
                        lawCheck.setChecked(true);
                    } else {
                        lawCheck.setChecked(false);
                    }
                }
            }
        });

        breakdown.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (breakdownCheck.isEnabled()) {
                    if (!breakdownCheck.isChecked()) {
                        breakdownCheck.setChecked(true);
                    } else {
                        breakdownCheck.setChecked(false);
                    }
                }
            }
        });

        blame.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!blameCheck.isChecked()) {
                    blameCheck.setChecked(true);
                } else {
                    blameCheck.setChecked(false);
                }
            }
        });


        next.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                SharedPreferences prefs = getActivity().getSharedPreferences(Constants.Prefs.MY_PREFS, Context.MODE_PRIVATE);
                SharedPreferences.Editor editor = prefs.edit();




                editor.putBoolean(Constants.Prefs.MEDICAL_ASSISTANCE, ambulanceCheck.isChecked());
                editor.putBoolean(Constants.Prefs.POLICE_ASSISTANCE, policeCheck.isChecked());
                editor.putBoolean(Constants.Prefs.ROAD_ASSISTANCE, breakdownCheck.isChecked());
                editor.putBoolean(Constants.Prefs.LAW_ASSISTANCE, lawCheck.isChecked());
                editor.putBoolean(Constants.Prefs.BLAME, blameCheck.isChecked());

                editor.apply();



                boolean[] flags = new boolean[5];

                String keyNumber = prefs.getString(Constants.Prefs.KEY_NUMBER, "");
                String clientID = prefs.getString(Constants.Prefs.CLIENT_ID, "");
                String contractNo = prefs.getString(Constants.Prefs.CONTRACT_NUMBER, "");
                String phone1 = prefs.getString(Constants.Prefs.PHONE_NUMBER_1, "");
                String phone2 = prefs.getString(Constants.Prefs.PHONE_NUMBER_2, "");
                String latitude = prefs.getString(Constants.Prefs.LATITUDE, "");
                String longitude = prefs.getString(Constants.Prefs.LONGITUDE, "");

                flags[0] = prefs.getBoolean(Constants.Prefs.MEDICAL_ASSISTANCE, false);
                flags[1] = prefs.getBoolean(Constants.Prefs.POLICE_ASSISTANCE, false);
                flags[2] = prefs.getBoolean(Constants.Prefs.ROAD_ASSISTANCE, false);
                flags[3] = prefs.getBoolean(Constants.Prefs.LAW_ASSISTANCE, false);
                flags[4] = prefs.getBoolean(Constants.Prefs.BLAME, false);

                SoapRequestManager requestManager = new SoapRequestManager(clientID, keyNumber, contractNo,
                        phone1, phone2, flags, latitude, longitude);
                requestManager.submitData();

                if (ambulanceCheck.isChecked() || policeCheck.isChecked()) {

                    FragmentManager manager = getFragmentManager();
                    FragmentTransaction transaction = manager.beginTransaction();

                    transaction.addToBackStack(null);
                    transaction.add(R.id.fragment_container, AccidentScreen.fragmentEmergencyCalls);
                    transaction.commit();

                }

            }
        });

        previous.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                getFragmentManager().popBackStack();
            }
        });


        return view;
    }

    @Override
    public void onResume() {
        super.onResume();
        SharedPreferences prefs = getActivity().getSharedPreferences(Constants.Prefs.MY_PREFS, Context.MODE_PRIVATE);

        String clientId = prefs.getString(Constants.Prefs.CLIENT_ID, "");
        String keyNumber = prefs.getString(Constants.Prefs.KEY_NUMBER, "");
        SoapRequestManager requestManager = new SoapRequestManager(clientId, keyNumber);
        requestManager.hasCheckBoxAccess();
    }

    @Override
    public void onStart() {
        super.onStart();

    }

    static void setEnabledBoxes(boolean[] access) {
        if (access != null) {
            Log.d ("TADE", "Access[0] is: " + access[0]);
            breakdownCheck.setEnabled(access[0]);
            /*
            Log.d ("TADE", "Access[1] is: " + access[1]);
            lawCheck.setEnabled(access[1]);*/
        }

    }

}
