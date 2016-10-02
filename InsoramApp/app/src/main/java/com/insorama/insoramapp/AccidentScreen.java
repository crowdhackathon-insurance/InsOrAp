package com.insorama.insoramapp;

import android.content.Context;
import android.content.SharedPreferences;
import android.location.Address;
import android.location.Geocoder;
import android.location.Location;
import android.media.tv.TvContract;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.GooglePlayServicesUtil;
import com.google.android.gms.common.api.GoogleApiActivity;
import com.google.android.gms.common.api.GoogleApiClient;
import com.google.android.gms.location.LocationListener;
import com.google.android.gms.location.LocationRequest;
import com.google.android.gms.location.LocationServices;
import java.util.List;
import java.util.Locale;

public class AccidentScreen extends AppCompatActivity implements GoogleApiClient.ConnectionCallbacks,
                                                        GoogleApiClient.OnConnectionFailedListener, LocationListener {

    static Context accidentContext;

    static FragmentChooseCar fragmentChooseCar = new FragmentChooseCar();
    static FragmentCheckBoxes fragmentCheckBoxes = new FragmentCheckBoxes();
    static FragmentEmergencyCalls fragmentEmergencyCalls = new FragmentEmergencyCalls();
    static TextView addressTV;

    LocationRequest mLocationRequest;
    GoogleApiClient mGoogleApiClient;


    static DataBaseManager dbManager;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_accident_screen);

        accidentContext = this;
        dbManager = new DataBaseManager(this);

        addressTV = (TextView) findViewById(R.id.accident_address_text);

        if (checkPlayServices()) {
            buildGoogleApiClient();
            createLocationRequest();
        }

        mGoogleApiClient.connect();



    }

    @Override
    protected void onStart() {
        super.onStart();

    }


    private boolean checkPlayServices() {
        int resultCode = GooglePlayServicesUtil
                .isGooglePlayServicesAvailable(this);
        if (resultCode != ConnectionResult.SUCCESS) {
            if (GooglePlayServicesUtil.isUserRecoverableError(resultCode)) {
                GooglePlayServicesUtil.getErrorDialog(resultCode, this, Constants.LocationServices.PLAY_SERVICES_RESOLUTION_REQUEST).show();
            } else {
                Toast.makeText(this, "This device is not supported", Toast.LENGTH_LONG).show();
                finishAffinity();
            }
            return false;
        }
        return true;
    }


    private void createLocationRequest() {
        Log.d ("INFO", "Creating location request");
        mLocationRequest = new LocationRequest()
                .setInterval(Constants.LocationServices.INTERVAL)
                .setPriority(LocationRequest.PRIORITY_HIGH_ACCURACY)
                .setNumUpdates(1);
    }

    private synchronized void buildGoogleApiClient() {
        mGoogleApiClient = new GoogleApiClient.Builder(this)
                .addConnectionCallbacks(this)
                .addOnConnectionFailedListener(this)
                .addApi(LocationServices.API)
                .build();
    }

    private void startLocationRequests() {
        try {
            LocationServices.FusedLocationApi.requestLocationUpdates(mGoogleApiClient, mLocationRequest, this);
            Log.d("INFO", "startLocationRequests: Started location requests");
        } catch (SecurityException e) {
            e.printStackTrace();
            Toast.makeText(this, "You have not accepted the location permissions(Required).", Toast.LENGTH_LONG).show();
        }
    }

    @Override
    public void onLocationChanged(Location location) {
        if (location != null) {
            SharedPreferences prefs = getSharedPreferences(Constants.Prefs.MY_PREFS, MODE_PRIVATE);
            SharedPreferences.Editor editor = prefs.edit();
            editor.putString(Constants.Prefs.LATITUDE, String.valueOf(location.getLatitude()));
            editor.putString(Constants.Prefs.LONGITUDE, String.valueOf(location.getLongitude()));
            editor.apply();

            Geocoder geocoder = new Geocoder(this, new Locale("el_GR"));
            try {
                List<Address> address = geocoder.getFromLocation(location.getLatitude(), location.getLongitude(), 1);
                if (address != null) {
                    addressTV.setText(addressTV.getText() + " " + address.get(0).getAddressLine(0));
                    addressTV.setVisibility(View.VISIBLE);
                    Toast.makeText(this, "Location Acquired. Continue", Toast.LENGTH_LONG).show();
                    FragmentManager fragmentManager = getSupportFragmentManager();
                    android.support.v4.app.FragmentTransaction transaction = fragmentManager.beginTransaction();

                    transaction.add(R.id.fragment_container,fragmentChooseCar);
                    transaction.commit();
                }
            } catch (Exception e) {
                e.printStackTrace();
                Toast.makeText(this, "Υπήρξε λάθος στην απόκτηση της τοποθεσίας σας. Παρακαλώ καλέστε την ασφαλιστική" +
                        " σας εταιρία", Toast.LENGTH_LONG).show();
            }
        }
    }

    @Override
    public void onConnectionFailed(ConnectionResult result) {
        Log.e ("ERROR-LOCATION", "" + result.getErrorMessage());
    }

    @Override
    public void onConnected(Bundle arg0) {
        startLocationRequests();
    }

    @Override
    public void onConnectionSuspended(int arg0) {
        //TODO: Do something
    }
}

