/*Practica #6 Medina Beltran Carlos Alberto - 18212216

-Elaborar un programa que reciba el precio y nombrede un producto, como parametro de salida mostrar
el total a pagar, incluir al subtotal el valor del IVA (16%).

Mostrar resultado en un mensaje flotante.*/
package com.example.p6u2_medinabeltrancarlosalberto;

import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    public EditText txtNom, txtNum;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        txtNom= findViewById(R.id.txtNom);
        txtNum= findViewById(R.id.txtNum);

        Log.e("error", "Solo numeros en el precio");
        Log.i("información", "Solo se encuentra texto");
        Log.w("advertencia", "saldra error si no llega los dos espacios");

    }

    public  void limpiar() {
        txtNom.setText("");
        txtNum.setText("");
    }

    public void mostrar(View v){
        String  nombre=txtNom.getText().toString();
        double  precio=Double.parseDouble(txtNum.getText().toString());
        double subtotal, total;

        subtotal = precio * 0.16;
        total = precio + subtotal;

        Toast.makeText(this, nombre + ": $" + total, Toast.LENGTH_SHORT).show();

        //para limpiar los numeros capturados
        limpiar();
    }
}