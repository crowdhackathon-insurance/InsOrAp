package com.insorama.insoramapp;

import android.os.AsyncTask;
import android.util.Log;
import android.widget.Toast;
import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class SoapRequestManager {
    private String clientID;
    private String keyNumber;

    private String contractNo;
    private String phone1;
    private String phone2;
    private boolean[] flags;
    private String latitude;
    private String longitude;
    private String friendlyArrangementLicensePlate;
    private String friendlyArrangementName;
    private String friendlyArrangementComments;
    private String shatter;

    private boolean canLogIn = false;
    private boolean[] checkBoxAccess;
    private String submitResponse;
    private boolean forCheckBoxes = false;
    private SoapRequestBundles.CarListBundle carList;

    public SoapRequestManager(String clientID, String keyNumber) {
        this.clientID = clientID;
        this.keyNumber = keyNumber;
    }

    public SoapRequestManager(String clientID, String keyNumber, String contractNo) {
        this.clientID = clientID;
        this.keyNumber = keyNumber;
        this.contractNo = contractNo;
        this.forCheckBoxes = true;
    }

    public SoapRequestManager(String clientID, String keyNumber, String contractNo, String phone1,
                              String phone2, boolean[] flags, String latitude, String longitude) {
        this.clientID = clientID;
        this.keyNumber = keyNumber;
        this.contractNo = contractNo;
        this.phone1 = phone1;
        this.phone2 = phone2;
        this.flags = flags;
        this.latitude = latitude;
        this.longitude = longitude;
    }

    public SoapRequestManager(String clientID, String keyNumber, String contractNo, String phone1,
                              String phone2, boolean[] flags, String latitude, String longitude,
                              String friendlyArrangementLicensePlate, String friendlyArrangementName, String friendlyArrangementComments) {
        this.clientID = clientID;
        this.keyNumber = keyNumber;
        this.contractNo = contractNo;
        this.phone1 = phone1;
        this.phone2 = phone2;
        this.flags = flags;
        this.latitude = latitude;
        this.longitude = longitude;
        this.friendlyArrangementLicensePlate = friendlyArrangementLicensePlate;
        this.friendlyArrangementName = friendlyArrangementName;
        this.friendlyArrangementComments = friendlyArrangementComments;
    }

    public void setShatter(String shatter) {
        this.shatter = shatter;
    }

    void signUp() {
        new AsyncTask<Void, Void, Void>() {
            @Override
            protected Void doInBackground(Void ... voidParams) {

                try {

                    SoapObject request = new SoapObject(Constants.SoapRequests.NAMESPACE,
                            Constants.SoapRequests.SIGN_UP_METHOD);

                    request.addProperty("KeyNumber", keyNumber);
                    request.addProperty("ClientID", clientID);
                    request.addProperty("HashCode", Constants.SoapRequests.HASHCODE);

                    SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
                    envelope.dotNet = true;
                    envelope.setOutputSoapObject(request);

                    HttpTransportSE transportSE = new HttpTransportSE(Constants.SoapRequests.URL);
                    transportSE.call (Constants.SoapRequests.SIGN_UP_SOAP_ACTION, envelope);

                    SoapObject response = (SoapObject) envelope.bodyIn;
                    canLogIn = response.getPropertyAsString(0).equals("1");
                    Log.i("INFO-RESPONSE", response.getPropertyAsString(0));

                } catch (Exception e) {
                    e.printStackTrace();
                    canLogIn = false;
                }



                return null;
            }

            @Override
            protected void onPostExecute(Void aVoid) {
                Log.d ("CAN-LOG-IN", String.valueOf(canLogIn));
                SignupScreen.loginHandler(canLogIn, keyNumber, clientID);
            }


        }.execute();
    }



    void getCarList() {
        new AsyncTask<Void, Void, Void>() {

            @Override
            protected Void doInBackground(Void... params) {

                try {
                    SoapObject request = new SoapObject(Constants.SoapRequests.NAMESPACE,
                            Constants.SoapRequests.GET_CAR_LIST_METHOD);

                    request.addProperty("KeyNumber", keyNumber);
                    request.addProperty("ClientID", clientID);
                    request.addProperty("HashCode", Constants.SoapRequests.HASHCODE);

                    SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
                    envelope.dotNet = true;
                    envelope.setOutputSoapObject(request);

                    HttpTransportSE transportSE = new HttpTransportSE(Constants.SoapRequests.URL, Constants.SoapRequests.TIMEOUT);
                    transportSE.call(Constants.SoapRequests.GET_CAR_LIST_ACTION, envelope);

                    SoapObject response = (SoapObject) envelope.getResponse();
                    SoapObject contractArray = (SoapObject) response.getProperty("ContractNumber");
                    SoapObject licenseArray = (SoapObject) response.getProperty("CarNumber");
                    SoapObject stolenArray = (SoapObject) response.getProperty("Stolen");
                    SoapObject fireArray = (SoapObject) response.getProperty("Fire");
                    SoapObject shatterArray = (SoapObject) response.getProperty("Shatter");

                    String[] contractNumbers = new String[contractArray.getPropertyCount()];
                    String[] licensePlates = new String[licenseArray.getPropertyCount()];
                    boolean[] stolens = new boolean[stolenArray.getPropertyCount()];
                    boolean[] fires = new boolean[fireArray.getPropertyCount()];
                    boolean[] shatters = new boolean[shatterArray.getPropertyCount()];

                    if (contractNumbers.length != licensePlates.length) {
                        contractNumbers = null;
                        licensePlates = null;
                    } else {
                        for (int i = 0; i < contractNumbers.length; i++) {
                            contractNumbers[i] = contractArray.getPropertyAsString(i);
                            licensePlates[i] = licenseArray.getPropertyAsString(i);
                            stolens[i] = Boolean.parseBoolean(stolenArray.getPropertyAsString(i));
                            fires[i] = Boolean.parseBoolean(fireArray.getPropertyAsString(i));
                            shatters[i] = Boolean.parseBoolean(shatterArray.getPropertyAsString(i));
                            Log.i ("INFO-SOAP-GET_CAR_LIST", "Contract Numbers: " + contractNumbers[i]
                            + " license plate: " + licensePlates[i]);
                        }
                    }
                    carList = new SoapRequestBundles(). new CarListBundle(contractNumbers, licensePlates,
                                stolens, fires, shatters);
                } catch (Exception e) {
                    e.printStackTrace();
                    carList = null;
                }

                return null;
            }

            protected void onPostExecute(Void aVoid) {
                if (carList != null) {
                    Map<String, String> map = carList.getCarList();

                    DataBaseManager dbManager = new DataBaseManager(SplashScreen.splashScreenContext);

                    int i = 0;
                    for (String s : map.keySet()) {
                        if (!dbManager.carExists(s)) {
                            String licenseNumber = map.get(s);
                            String stolen = String.valueOf(carList.getStolen()[i]);
                            String fire = String.valueOf(carList.getFire()[i]);
                            String shatter = String.valueOf(carList.getShatter()[i]);
                            CarInfo carInfo = new CarInfo("", licenseNumber, s, stolen, fire, shatter);
                            dbManager.addNewCar(carInfo);
                        }
                        i++;
                    }
                } else {
                    Toast.makeText(SplashScreen.splashScreenContext, "There has been an error", Toast.LENGTH_LONG).show();
                }

            }
        }.execute();
    }

    void hasCheckBoxAccess() {
        new AsyncTask<Void, Void, Void>() {

            @Override
            protected Void doInBackground(Void ... params) {
                try {

                    SoapObject request = new SoapObject(Constants.SoapRequests.NAMESPACE,
                            Constants.SoapRequests.CHECKBOX_ACCESS_METHOD);
                    request.addProperty("ClientID", clientID);
                    request.addProperty("KeyNumber", keyNumber);
                    request.addProperty("Symvolaio_ID", contractNo);
                    request.addProperty("HashCode", Constants.SoapRequests.HASHCODE);

                    SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
                    envelope.dotNet = true;
                    envelope.setOutputSoapObject(request);

                    HttpTransportSE transportSE = new HttpTransportSE(Constants.SoapRequests.URL);
                    transportSE.call(Constants.SoapRequests.CHECKBOX_ACCESS_ACTION, envelope);

                    SoapObject response = (SoapObject) envelope.bodyIn;
                    SoapObject booleanArray = (SoapObject) response.getProperty(0);

                    checkBoxAccess = new boolean[booleanArray.getPropertyCount()];

                    for (int i = 0; i < checkBoxAccess.length; i++) {
                        checkBoxAccess[i] = Boolean.parseBoolean(booleanArray.getPropertyAsString(i));
                    }

                } catch (Exception e) {
                    e.printStackTrace();
                    checkBoxAccess = null;
                }



                return null;
            }

            @Override
            protected void onPostExecute(Void aVoid) {
                FragmentCheckBoxes.setEnabledBoxes(checkBoxAccess);
            }

        }.execute();

    }

    void submitData() {
        new AsyncTask<Void, Void, Void>() {

            @Override
            protected Void doInBackground(Void ... params) {

                try {
                    SoapObject request = new SoapObject (Constants.SoapRequests.NAMESPACE,
                            Constants.SoapRequests.SUBMIT_ACCIDENT_METHOD);
                    SoapObject booleanArrayProperty = new SoapObject (Constants.SoapRequests.NAMESPACE,
                            "CheckBoxes");
                    request.addProperty("ClientID", clientID);
                    request.addProperty("KeyNumber", keyNumber);
                    request.addProperty("Symvolaio_ID", contractNo);
                    request.addProperty("phone1", phone1);
                    request.addProperty("phone2", phone2);

                    for (int i = 0; i < flags.length; i++) {
                        booleanArrayProperty.addProperty("boolean", flags[i]);
                    }
                    request.addSoapObject(booleanArrayProperty);

                    request.addProperty("Latitude", latitude);
                    request.addProperty("Longitude", longitude);
                    request.addProperty("HashCode", Constants.SoapRequests.HASHCODE);

                    SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
                    envelope.dotNet = true;
                    envelope.setOutputSoapObject(request);

                    HttpTransportSE transportSE = new HttpTransportSE(Constants.SoapRequests.URL);
                    transportSE.call(Constants.SoapRequests.SUBMIT_ACCIDENT_ACTION, envelope);

                    SoapObject response = (SoapObject) envelope.bodyIn;
                    submitResponse = response.getPropertyAsString(0);

                } catch (Exception e) {
                    e.printStackTrace();
                    submitResponse = "0";
                }
                return null;
            }

            @Override
            protected void onPostExecute(Void aVoid) {
                if (submitResponse.equals("1")) {
                    Toast.makeText(SplashScreen.splashScreenContext, "Η δήλωσή σας καταχωρήθηκε επιτυχώς", Toast.LENGTH_LONG).show();
                } else {
                    Toast.makeText(SplashScreen.splashScreenContext, "Υπήρξε κάποιο πρόβλημα στη δήλωσή σας. Παρακαλώ" +
                            " προσπαθήστε ξανά.", Toast.LENGTH_LONG).show();
                }
            }
        }.execute();
    }

    void submitDataExtended() {
        new AsyncTask<Void, Void, Void>() {
            @Override
            protected Void doInBackground(Void ... params) {

                try {

                    SoapObject request = new SoapObject (Constants.SoapRequests.NAMESPACE,
                            Constants.SoapRequests.SUBMIT_ACCIDENT_EXTENDED_METHOD);
                    SoapObject booleanArrayProperty = new SoapObject (Constants.SoapRequests.NAMESPACE,
                            "CheckBoxes");
                    request.addProperty("ClientID", clientID);
                    request.addProperty("KeyNumber", keyNumber);
                    request.addProperty("Symvolaio_ID", contractNo);
                    request.addProperty("phone1", phone1);
                    request.addProperty("phone2", phone2);

                    for (int i = 0; i < flags.length; i++) {
                        booleanArrayProperty.addProperty("boolean", flags[i]);
                    }
                    request.addSoapObject(booleanArrayProperty);

                    request.addProperty("Latitude", latitude);
                    request.addProperty("Longitude", longitude);
                    request.addProperty("FriendlyArrangementLicensePlate", friendlyArrangementLicensePlate);
                    request.addProperty("FriendlyArrangementName", friendlyArrangementName);
                    request.addProperty("FriendlyArrangementComments", friendlyArrangementComments);
                    request.addProperty("HashCode", Constants.SoapRequests.HASHCODE);

                    SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
                    envelope.dotNet = true;
                    envelope.setOutputSoapObject(request);

                    HttpTransportSE transportSE = new HttpTransportSE(Constants.SoapRequests.URL);
                    transportSE.call(Constants.SoapRequests.SUBMIT_ACCIDENT_EXTENDED_ACTION, envelope);

                    SoapObject response = (SoapObject) envelope.bodyIn;
                    submitResponse = response.getPropertyAsString(0);

                } catch (Exception e) {
                    e.printStackTrace();
                    submitResponse = "";
                }

                return null;
            }

            @Override
            protected void onPostExecute(Void aVoid) {
                if (submitResponse.equals("1")) {
                    Toast.makeText(SplashScreen.splashScreenContext, "Η δήλωσή σας καταχωρήθηκε επιτυχώς", Toast.LENGTH_LONG).show();
                } else {
                    Toast.makeText(SplashScreen.splashScreenContext, "Υπήρξε κάποιο πρόβλημα στη δήλωσή σας. Παρακαλώ" +
                            " προσπαθήστε ξανά.", Toast.LENGTH_LONG).show();
                }
            }
        }.execute();
    }

    void submitTheft() {
        new AsyncTask<Void, Void, Void>() {
            protected Void doInBackground(Void ... params) {

                try {
                    SoapObject request = new SoapObject(Constants.SoapRequests.NAMESPACE,
                            Constants.SoapRequests.SUBMIT_PROBLEM_DATA_METHOD);
                    request.addProperty("ClientID", clientID);
                    request.addProperty("KeyNumber", keyNumber);
                    request.addProperty("Symvolaio_ID", contractNo);
                    request.addProperty("ProblemType", Constants.SoapRequests.SUBMIT_THEFT_ID);
                    request.addProperty("Shatter", "");
                    request.addProperty("HashCode", Constants.SoapRequests.HASHCODE);


                    SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
                    envelope.dotNet = true;
                    envelope.setOutputSoapObject(request);

                    HttpTransportSE transportSE = new HttpTransportSE(Constants.SoapRequests.URL, Constants.SoapRequests.TIMEOUT);
                    transportSE.call(Constants.SoapRequests.SUBMIT_PROBLEM_DATA_ACTION, envelope);

                    SoapObject response = (SoapObject) envelope.bodyIn;
                    submitResponse = response.getPropertyAsString(0);

                } catch (Exception e) {
                    e.printStackTrace();
                    submitResponse = "0";
                }

                return null;
            }

            protected void onPostExecute(Void aVoid) {
                if (submitResponse.equals("1")) {
                    Toast.makeText(SplashScreen.splashScreenContext, "Theft has been submited successfully", Toast.LENGTH_LONG).show();
                } else {
                    Toast.makeText(SplashScreen.splashScreenContext, "There has been an error. Please try again",
                            Toast.LENGTH_LONG).show();
                }
            }
        }.execute();
    }

    void submitFire() {
        new AsyncTask<Void, Void, Void>() {
            protected Void doInBackground(Void ... params) {

                try {
                    SoapObject request = new SoapObject(Constants.SoapRequests.NAMESPACE,
                            Constants.SoapRequests.SUBMIT_PROBLEM_DATA_METHOD);
                    request.addProperty("ClientID", clientID);
                    request.addProperty("KeyNumber", keyNumber);
                    request.addProperty("Symvolaio_ID", contractNo);
                    request.addProperty("ProblemType", Constants.SoapRequests.SUBMIT_FIRE_ID);
                    request.addProperty("Shatter", "");
                    request.addProperty("HashCode", Constants.SoapRequests.HASHCODE);

                    SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
                    envelope.dotNet = true;
                    envelope.setOutputSoapObject(request);

                    HttpTransportSE transportSE = new HttpTransportSE(Constants.SoapRequests.URL);
                    transportSE.call(Constants.SoapRequests.SUBMIT_PROBLEM_DATA_ACTION, envelope);

                    SoapObject response = (SoapObject) envelope.bodyIn;
                    submitResponse = response.getPropertyAsString(0);

                } catch (Exception e) {
                    e.printStackTrace();
                    submitResponse = "0";
                }

                return null;
            }

            @Override
            protected void onPostExecute(Void aVoid) {
                if (submitResponse.equals("1")) {
                    Toast.makeText(SplashScreen.splashScreenContext, "Theft has been submited successfully", Toast.LENGTH_LONG).show();
                } else {
                    Toast.makeText(SplashScreen.splashScreenContext, "There has been an error. Please try again",
                            Toast.LENGTH_LONG).show();
                }
            }
        }.execute();
    }

    public void submitShatter() {
        new AsyncTask<Void, Void, Void>() {
            @Override
            protected Void doInBackground(Void ... params) {

                try {

                    SoapObject request = new SoapObject(Constants.SoapRequests.NAMESPACE,
                            Constants.SoapRequests.SUBMIT_PROBLEM_DATA_METHOD);
                    request.addProperty("ClientID", clientID);
                    request.addProperty("KeyNumber", keyNumber);
                    request.addProperty("Symvolaio_ID", contractNo);
                    request.addProperty("ProblemType", Constants.SoapRequests.SUBMIT_SHATTER_ID);
                    request.addProperty("Shatter", shatter);
                    request.addProperty("HashCode", Constants.SoapRequests.HASHCODE);

                    SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
                    envelope.dotNet = true;
                    envelope.setOutputSoapObject(request);

                    HttpTransportSE transportSE = new HttpTransportSE(Constants.SoapRequests.URL);
                    transportSE.call(Constants.SoapRequests.SUBMIT_PROBLEM_DATA_ACTION, envelope);

                    SoapObject response = (SoapObject) envelope.bodyIn;
                    submitResponse = response.getPropertyAsString(0);

                } catch (Exception e) {
                    e.printStackTrace();
                    submitResponse = "0";
                }

                return null;
            }

            @Override
            protected void onPostExecute(Void aVoid) {
                if (submitResponse.equals("1")) {
                    Toast.makeText(SplashScreen.splashScreenContext, "Theft has been submited successfully", Toast.LENGTH_LONG).show();
                } else {
                    Toast.makeText(SplashScreen.splashScreenContext, "There has been an error. Please try again",
                            Toast.LENGTH_LONG).show();
                }
            }
        }.execute();
    }


}
