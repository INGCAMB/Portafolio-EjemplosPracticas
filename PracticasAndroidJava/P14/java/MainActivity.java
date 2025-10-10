package com.example.p14u2_medinabeltrancarlosalberto;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

public class MainActivity extends AppCompatActivity {

    String[] datos = new String[]{"Alberto", "Beltran", "Otay", "22"};

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    //Método parar el botón enviar
    public void Enviar(View view){

        Bundle enviaDatos = new Bundle();
        enviaDatos.putStringArray("keyDatos", datos);

        Intent i = new Intent(this, MainActivityDos.class);
        i.putExtras(enviaDatos);
        startActivity(i);
    }
}