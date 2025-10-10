package com.example.p13u2_medinabeltrancarlosalberto;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

public class Ingreso extends AppCompatActivity {
    public TextView tv1, tv2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_ingreso);

        tv1 = findViewById(R.id.tv1);
        tv2 = findViewById(R.id.tv2);

        String DatoNom = getIntent().getStringExtra("Nombre");
        String DatoClave = getIntent().getStringExtra("Clave");
        Toast.makeText(this, "Bienvenido a la aplicación", Toast.LENGTH_SHORT).show();

        tv1.setText("Usuario: " + DatoNom + " Clave: " + DatoClave);
        tv2.setText(DatoNom + ",es el usuario recuperado en el segundo activity");
    }
}