/*Practica #5 Medina Beltran Carlos Alberto - 18212216

-Elaborar un programa que reciba una clave como parametro de entrada y al dar clic a un botón
llamado MOSTRAR, retorna un mensaje flotante con la descripción de la categoría.

Tabla de valores:
Case - Categoria
115 - Premium
756 - VIP
650 - Frecuente
default - No existe categoría

Recomendación: en código java pueden usar la estructura de selección if o estructura de control
switch.*/
package com.example.p5u2_medinabeltrancarlosalberto;

import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    public EditText txtNum1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        txtNum1= findViewById(R.id.txtNum1);

        Log.e("error", "Solo numeros");
        Log.i("información", "Solo se encuentra texto");
    }

    public  void limpiar() {
        txtNum1.setText("");
    }

    public void mostrar(View v){
        int clave= Integer.parseInt(txtNum1.getText().toString());

        if(clave == 115){
            Toast.makeText(this, "Premium", Toast.LENGTH_SHORT).show();
        }
        else if(clave == 756){
            Toast.makeText(this, "VIP", Toast.LENGTH_SHORT).show();
        }
        else if(clave == 650){
            Toast.makeText(this, "Frecuente", Toast.LENGTH_SHORT).show();
        }
        else
        {
            Toast.makeText(this, "No existe categoría", Toast.LENGTH_SHORT).show();
        }

        //para limpiar los numeros capturados
        limpiar();
    }
}