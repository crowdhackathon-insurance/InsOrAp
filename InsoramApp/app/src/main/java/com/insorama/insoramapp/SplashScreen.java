package com.insorama.insoramapp;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.ImageView;

public class SplashScreen extends AppCompatActivity {

    static Context splashScreenContext;
    SharedPreferences prefs;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_splash_screen);

        this.splashScreenContext = this;

        prefs = getSharedPreferences(Constants.Prefs.MY_PREFS, MODE_PRIVATE);

        Animation alpha = AnimationUtils.loadAnimation(this, R.anim.fade_in);
        ImageView logo = (ImageView) findViewById(R.id.logo);
        logo.startAnimation(alpha);

        alpha.setAnimationListener(new Animation.AnimationListener() {
            @Override
            public void onAnimationStart(Animation animation) {

            }

            @Override
            public void onAnimationEnd(Animation animation) {
                if (prefs.getString(Constants.Prefs.CLIENT_ID, null) == null ||
                        prefs.getString(Constants.Prefs.KEY_NUMBER, null) == null) {
                    startActivity(new Intent(SplashScreen.this, SignupScreen.class));
                } else {
                    startActivity(new Intent(SplashScreen.this, MainScreen.class));
                }
            }

            @Override
            public void onAnimationRepeat(Animation animation) {

            }
        });

    }
}
