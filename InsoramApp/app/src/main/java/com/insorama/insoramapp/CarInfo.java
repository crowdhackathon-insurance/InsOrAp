package com.insorama.insoramapp;

public class CarInfo {
    private String contractNumber;
    private String licensePlate;
    private String friendlyName;
    private String stolenAccess;
    private String fireAccess;
    private String shatterAccess;
    private boolean extended;

    public CarInfo(String friendlyName, String licensePlate, String contractNumber) {
        this.contractNumber = contractNumber;
        this.licensePlate = licensePlate;
        this.friendlyName = friendlyName;
        extended = false;
    }

    public CarInfo(String friendlyName, String licensePlate, String contractNumber,
                   String stolenAccess, String fireAccess, String shatterAccess) {
        this.contractNumber = contractNumber;
        this.licensePlate = licensePlate;
        this.friendlyName = friendlyName;
        this.stolenAccess = stolenAccess;
        this.fireAccess = fireAccess;
        this.shatterAccess = shatterAccess;
        extended = true;

    }

    public boolean getStolenAccessAsBoolean() { return Boolean.parseBoolean(stolenAccess); }
    public boolean getFireAccessAsBoolean() { return Boolean.parseBoolean(fireAccess); }
    public boolean getShatterAccessAsBoolean() { return Boolean.parseBoolean(shatterAccess); }
    public String getContractNumber() { return contractNumber; }
    public String getLicensePlate() { return licensePlate; }
    public String getFriendlyName() { return friendlyName; }
    public String getStolenAccess() { return stolenAccess; }
    public String getFireAccess() { return fireAccess; }
    public String getShatterAccess() { return shatterAccess; }

    public boolean isExtended() { return extended; }
}
