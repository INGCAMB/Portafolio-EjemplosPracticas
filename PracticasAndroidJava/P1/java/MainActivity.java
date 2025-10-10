/*Practica #1 Medina Beltran Carlos Alberto - 18212216

-Elaborar una aplicación donde exista un botón en el centro y al darle clic debe mostrar un mensaje
de su preferencia, ejemplo “Bienvenido Android Studio”*/
package com.example.p1u2_medinabeltrancarlosalberto;

import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Toast;
import android.content.Context;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void entrar(View v){
        Context context = getApplicationContext();
        CharSequence text = "Bienvenido Alberto Beltran";
        int duration = Toast.LENGTH_SHORT;

        Toast.makeText(context, text, duration).show();

        //Toast.makeText(this, "Bienvenido Alberto Beltran", Toast.LENGTH_SHORT).show();
    }
}