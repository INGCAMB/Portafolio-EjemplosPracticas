package com.example.p13u2_medinabeltrancarlosalberto;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.text.Editable;
import android.view.View;
import android.widget.EditText;

public class Cuenta extends AppCompatActivity {
    private EditText et1, et2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cuenta);

        et1 = findViewById(R.id.et1);
        et2 = findViewById(R.id.et2);
    }

    //Método parar el botón enviar
    public void Confirmar(View view){
        Intent i = new Intent(this, Ingreso.class);
        i.putExtra("Nombre", et1.getText().toString());
        i.putExtra("Clave", et2.getText().toString());
        startActivity(i);
    }

    //Método parar el botón cancelar
    public void Cancelar(View view){
        Intent i = new Intent(this, MainActivity.class);
        startActivity(i);
    }
}