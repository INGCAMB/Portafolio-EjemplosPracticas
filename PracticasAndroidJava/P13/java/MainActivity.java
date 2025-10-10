package com.example.p13u2_medinabeltrancarlosalberto;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


    }

    //Método parar el botón Login
    public void Enviar(View view){
        Intent i = new Intent(this, Cuenta.class);
        startActivity(i);
    }
}