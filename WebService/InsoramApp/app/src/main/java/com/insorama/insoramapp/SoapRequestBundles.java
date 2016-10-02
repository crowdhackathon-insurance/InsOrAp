package com.insorama.insoramapp;


import java.util.HashMap;
import java.util.Map;

public class SoapRequestBundles {
    public class CarListBundle {
        private Map<String, String> carList;
        boolean[] stolen;
        boolean[] fire;
        boolean[] shatter;

        public CarListBundle(String[] contractNumbers, String[] licensePlates, boolean[] stolen, boolean[] fire, boolean[] shatter) {
            carList = new HashMap<>();
            for (int i=0; i < contractNumbers.length; i++) {
                carList.put(contractNumbers[i], licensePlates[i]);
            }
            this.stolen = stolen;
            this.fire = fire;
            this.shatter = shatter;
        }

        Map<String, String> getCarList () {
            return carList;
        }



        public boolean[] getStolen() { return stolen; }
        public boolean[] getFire() { return fire; }
        public boolean[] getShatter() { return shatter; }
    }
}
