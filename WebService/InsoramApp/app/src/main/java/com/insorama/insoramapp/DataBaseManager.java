package com.insorama.insoramapp;


import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

import java.util.ArrayList;
import java.util.List;

public class DataBaseManager extends SQLiteOpenHelper {

    public DataBaseManager(Context context) {
        super(context, Constants.Db.DB_NAME, null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        String CREATE_TABLE = "create table " + Constants.Db.TABLE_NAME + "(" +
                Constants.Db.COL_NAME + " TEXT, " + Constants.Db.COL_LICENSE + " TEXT, "
                + Constants.Db.COL_CONTRACT + " TEXT primary key, " +
                Constants.Db.COL_STOLEN_ASSISTANCE + " TEXT, " +
                Constants.Db.COL_FIRE_ASSISTANCE + " TEXT, " +
                Constants.Db.COL_SHATTER_ASSiSTANCE + " TEXT)";
        sqLiteDatabase.execSQL(CREATE_TABLE);

    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {
        sqLiteDatabase.execSQL("drop table if exists " + Constants.Db.TABLE_NAME);
        onCreate(sqLiteDatabase);
    }

    public boolean addNewCar(CarInfo carInfo) {
        Log.i ("ADDING", "Adding values");
        SQLiteDatabase db = this.getWritableDatabase();

        try {
            ContentValues values = new ContentValues();
            values.put(Constants.Db.COL_NAME, carInfo.getFriendlyName());
            values.put(Constants.Db.COL_LICENSE, carInfo.getLicensePlate());
            values.put(Constants.Db.COL_CONTRACT, carInfo.getContractNumber());
            if (carInfo.isExtended()) {
                values.put(Constants.Db.COL_STOLEN_ASSISTANCE, carInfo.getStolenAccess());
                values.put(Constants.Db.COL_FIRE_ASSISTANCE, carInfo.getFireAccess());
                values.put(Constants.Db.COL_SHATTER_ASSiSTANCE, carInfo.getShatterAccess());
            } else {
                values.put(Constants.Db.COL_STOLEN_ASSISTANCE, "false");
                values.put(Constants.Db.COL_FIRE_ASSISTANCE, "false");
                values.put(Constants.Db.COL_SHATTER_ASSiSTANCE, "false");
            }

            long tmp = db.insert(Constants.Db.TABLE_NAME, null, values);
            return tmp != -1 || replaceValue(carInfo.getFriendlyName(), carInfo.getContractNumber());
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }
    }

    public CarInfo getSpecificCar(String contractNumber) {
        CarInfo tmp;
        SQLiteDatabase db = this.getWritableDatabase();
        String query = "select * from " + Constants.Db.TABLE_NAME + " where " + Constants.Db.COL_CONTRACT + " = '" + contractNumber + "'";
        Cursor cursor = db.rawQuery(query, null);
        if (cursor.moveToFirst()) {
            String friendlyName = cursor.getString(cursor.getColumnIndex(Constants.Db.COL_NAME));
            String licensePlate = cursor.getString(cursor.getColumnIndex(Constants.Db.COL_LICENSE));
            String contractNo = cursor.getString(cursor.getColumnIndex(Constants.Db.COL_CONTRACT));
            String stolenAccess = cursor.getString(cursor.getColumnIndex(Constants.Db.COL_STOLEN_ASSISTANCE));
            String fireAccess = cursor.getString(cursor.getColumnIndex(Constants.Db.COL_FIRE_ASSISTANCE));
            String shatterAccess = cursor.getString(cursor.getColumnIndex(Constants.Db.COL_SHATTER_ASSiSTANCE));
            tmp = new CarInfo(friendlyName, licensePlate, contractNo, stolenAccess, fireAccess, shatterAccess);
            cursor.close();
        } else {
            tmp = null;
        }

        return tmp;
    }

    public boolean carExists(String contractNumber) {
        SQLiteDatabase db = this.getWritableDatabase();
        String query = "select * from " + Constants.Db.TABLE_NAME + " where " + Constants.Db.COL_CONTRACT + " = '" + contractNumber + "'";
        Cursor cursor = db.rawQuery(query, null);
        int tmp = cursor.getCount();
        cursor.close();
        return tmp != 0;
    }

    public List<CarInfo> getAllCars() {
        List<CarInfo> carList = new ArrayList<>();
        SQLiteDatabase db = this.getWritableDatabase();
        String query = "select * from " + Constants.Db.TABLE_NAME;
        Cursor cursor = db.rawQuery(query, null);
        if (cursor.moveToFirst()) {
            do {
                String friendlyName = cursor.getString(cursor.getColumnIndex(Constants.Db.COL_NAME));
                String licensePlate = cursor.getString(cursor.getColumnIndex(Constants.Db.COL_LICENSE));
                String contractNumber = cursor.getString(cursor.getColumnIndex(Constants.Db.COL_CONTRACT));
                String stolenAccess = cursor.getString(cursor.getColumnIndex(Constants.Db.COL_STOLEN_ASSISTANCE));
                String fireAccess = cursor.getString(cursor.getColumnIndex(Constants.Db.COL_FIRE_ASSISTANCE));
                String shatterAccess = cursor.getString(cursor.getColumnIndex(Constants.Db.COL_SHATTER_ASSiSTANCE));

                CarInfo info = new CarInfo(friendlyName, licensePlate, contractNumber, stolenAccess, fireAccess, shatterAccess);
                carList.add(info);

            } while (cursor.moveToNext());
        }
        cursor.close();
        return carList;
    }



    public int getCarAmount() {
        String query = "select * from " + Constants.Db.TABLE_NAME;
        SQLiteDatabase db = this.getReadableDatabase();
        return db.rawQuery(query, null).getCount();
    }

   public  boolean replaceValue(String friendlyName, String contractNumber) {
        Log.i ("REPLACING", "Replacing values");
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put(Constants.Db.COL_NAME, friendlyName);
        values.put(Constants.Db.COL_CONTRACT, contractNumber);
        long tmp;
        try {
            tmp = db.update(Constants.Db.TABLE_NAME, values, Constants.Db.COL_CONTRACT + " = '" + contractNumber + "'", null);
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }
        return tmp != -1;
    }

    public String getByFriendlyName(String friendlyName) {
        SQLiteDatabase db = this.getWritableDatabase();
        String query = "select * from " + Constants.Db.TABLE_NAME + " where " + Constants.Db.COL_NAME
                + " ='" + friendlyName + "'";
        Cursor cursor = db.rawQuery(query, null);
        String tmp = cursor.getString(cursor.getColumnIndex(Constants.Db.COL_CONTRACT));
        cursor.close();
        return tmp;

    }

    public void deleteAll() {
        SQLiteDatabase db = this.getWritableDatabase();
        db.delete(Constants.Db.TABLE_NAME, null, null);
    }
}
