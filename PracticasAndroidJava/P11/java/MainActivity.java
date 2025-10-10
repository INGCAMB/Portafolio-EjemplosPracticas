/*
Elaborar una aplicación para implementar en un Container el componente ScrollView.
- Mostrar dos preguntas de un tema en específico.
- Permitir al usuario seleccionar la respuesta a través de una imagen.
*/
package com.example.p11u2_medinabeltrancarlosalberto;

import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    TextView  tv1, tv2;
    ImageButton imageButton3, imageButton4;
    String genero, colorojos;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        tv1=findViewById(R.id.tv1);
        tv2=findViewById(R.id.tv2);
        imageButton3=findViewById(R.id.imageButton3);
        imageButton4=findViewById(R.id.imageButton4);

        //Crear un numero aleatorio entre 0 y 2 para los generos
        int nro= (int) (Math.random()*2);
        switch (nro){
            case 1: genero="hombre";break;
            case 2: genero="mujer";break;
            //default: genero="No registrado";break;
        }
        tv1.setText("Genero " + genero);
    }

    public void entrar(View v){
        ImageButton b=(ImageButton)v;
        if(b.getTag().toString().equals(genero)){
            Toast.makeText(MainActivity.this, "Muy bien!!!", Toast.LENGTH_SHORT).show();
            tv2.setVisibility(View.VISIBLE);
            imageButton3.setVisibility(View.VISIBLE);
            imageButton4.setVisibility(View.VISIBLE);
            //Crear un numero aleatorio entre 0 y 2 para los ojos
            int nro2= (int) (Math.random()*2);
            switch (nro2){
                case 1: colorojos="ojoazul";break;
                case 2: colorojos="ojoverde";break;
                //default: colorojos="No registrado";break;
            }
            tv2.setText("Color de " + colorojos);
        }else{
            Toast.makeText(MainActivity.this, "Es incorrecto, seleccionaste el genero " + b.getTag().toString(), Toast.LENGTH_SHORT).show();
        }
    }

    public void entrar2(View v){
        ImageButton b=(ImageButton)v;
        if(b.getTag().toString().equals(colorojos)){
            Toast.makeText(MainActivity.this, "Muy bien!!!", Toast.LENGTH_SHORT).show();
        }else{
            Toast.makeText(MainActivity.this, "Es incorrecto, seleccionaste el color de " + b.getTag().toString(), Toast.LENGTH_SHORT).show();
        }
    }
}