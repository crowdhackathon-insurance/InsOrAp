package com.insorama.insoramapp;

import android.app.ProgressDialog;
import android.content.Context;

public class ProgressDialogManager {

    private Context thisContext;
    private String title;
    private ProgressDialog progress;

    public ProgressDialogManager(Context context, String title) {
        thisContext = context;
        this.title = title;
    }

    void startProgress(String message) {
        progress = ProgressDialog.show(thisContext, title, message, true);
        progress.setCancelable(true);

    }

    void changeMessage(String message) {
        progress.setMessage(message);
    }

    void cancelProgess() {
        progress.dismiss();
    }
}
