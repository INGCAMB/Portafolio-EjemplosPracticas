package com.example.p14u2_medinabeltrancarlosalberto;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;

public class MainActivityDos extends AppCompatActivity {
    TextView tv1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_dos);

        tv1 = findViewById(R.id.tv1);

        Bundle recibirDatos = getIntent().getExtras();
        String[] info = recibirDatos.getStringArray("keyDatos");

        tv1.setText("Nombre: " + info[0] + "\nApellido: " + info[1] + "\nDirección: " + info[2] + "\nEdad: "  + info[3]);
    }
}