package com.insorama.insoramapp;

import android.content.SharedPreferences;

import java.util.HashMap;
import java.util.Map;

public class Constants {
    static public class Prefs {
        static String MY_PREFS = "insoramapp_prefs";

        static String PHONE_NUMBER_1 = "phone_number_1";
        static String PHONE_NUMBER_2 = "phone_number_2";

        static String MEDICAL_ASSISTANCE = "medical_assistance";
        static String POLICE_ASSISTANCE = "police_assistance";
        static String ROAD_ASSISTANCE = "road_assistance";
        static String LAW_ASSISTANCE = "law_assistance";
        static String BLAME = "blame";

        static String LICENSE_PLATE = "licensePlate";
        static String KEY_NUMBER = "key_number";
        static String CLIENT_ID = "client_id";

        static String CONTRACT_NUMBER = "contract_number";

        static String LATITUDE = "lat";
        static String LONGITUDE = "lng";

        static String INSURANCE_NUMBER = "6948759487";
        static String POLICE_NUMBER = "6974790154";
        static String AMBULANCE_NUMBER = "6945864561";

    }

    static class LocationServices {
        static long INTERVAL = 1000;
        static int PLAY_SERVICES_RESOLUTION_REQUEST = 500;
        static int GEO_SUCCESS = 0;
        static int GEO_FAILURE = 1;
    }

    static class SoapRequests {

        static String HASHCODE = "InsOrApp@20160919!789456123";

        //static String URL = "http://insoramap.ddns.net:8080/insorwebservice/InsOrService.asmx";
        //static String URL = "http://192.168.1.251/insomaWebService/InsOrService.asmx";
        static String URL = "http://192.168.177.157/insorwebservice/insorservice.asmx";

        static String NAMESPACE = "http://tempuri.org/";

        static String TEST_SOAP_ACTION = "http://tempuri.org/HelloWorld";
        static String TEST_SOAP_METHOD = "HelloWorld";

        static String SIGN_UP_SOAP_ACTION = "http://tempuri.org/SignUp";
        static String SIGN_UP_METHOD = "SignUp";

        static String CHECKBOX_ACCESS_ACTION = "http://tempuri.org/CheckboxAccess";
        static String CHECKBOX_ACCESS_METHOD = "CheckboxAccess";

        static String SUBMIT_ACCIDENT_ACTION = "http://tempuri.org/SubmitData";
        static String SUBMIT_ACCIDENT_METHOD = "SubmitData";

        static String SUBMIT_ACCIDENT_EXTENDED_ACTION = "http://tempuri.org/SubmitDataExtended";
        static String SUBMIT_ACCIDENT_EXTENDED_METHOD = "SubmitDataExtended";

        static String GET_CAR_LIST_ACTION = "http://tempuri.org/GetCarList";
        static String GET_CAR_LIST_METHOD = "GetCarList";

        static String SUBMIT_PROBLEM_DATA_ACTION = "http://tempuri.org/SubmitProblem";
        static String SUBMIT_PROBLEM_DATA_METHOD = "SubmitProblem";

        static int SUBMIT_THEFT_ID = 0;
        static int SUBMIT_FIRE_ID = 1;
        static int SUBMIT_SHATTER_ID = 2;

        static int TIMEOUT = 10000;
    }

    static class Strings {
        static String SIGN_UP_REPONSE = "sign_up";
    }

    static class Db {
        static String DB_NAME = "car_data.db";
        static String TABLE_NAME = "declared_car_data_table";
        static String COL_NAME = "friendly_name";
        static String COL_LICENSE = "license_plate";
        static String COL_CONTRACT = "contract_number";
        static String COL_STOLEN_ASSISTANCE = "stolen_assistance";
        static String COL_FIRE_ASSISTANCE = "fire_assistance";
        static String COL_SHATTER_ASSiSTANCE = "shatter_assistance";
    }

    //added by Thanasis
    public static class StrText {
        public static String sucToastMes = "Επιλέξατε το αυτοκίνητο: ";
        public static String carWarningMes = "Δεν Επιλέξατε Αυτοκίνητο";
        public static String shatterWarningMes = "Δεν Επιλέξατε Κατεστραμένα Κρύσταλλα";
        public static String fireWarningMes = "Δεν Επιλέξατε Ποσοστό Καταστροφής";
    }
}
