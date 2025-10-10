/*Practica #2 Medina Beltran Carlos Alberto - 18212216

-Elaborar una aplicacion para la suma de dos numeros*/
package com.example.p2u2_medinabeltrancarlosalberto;

import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {
    public EditText txtNum1, txtNum2;
    public TextView txtView1;
    Button btnSumar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        txtNum1= findViewById(R.id.txtNum1);
        txtNum2= findViewById(R.id.txtNum2);
        txtView1= findViewById(R.id.txtView1);
        btnSumar= findViewById(R.id.btn1);
        btnSumar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                int valor1= Integer.parseInt(txtNum1.getText().toString());
                int valor2= Integer.parseInt(txtNum2.getText().toString());
                int resultado= valor1+valor2;

                txtView1.setText(String.valueOf(resultado));

                //para limpiar los numeros capturados
                limpiar();
            }
        });

    }

    public  void limpiar() {
        txtNum1.setText("");
        txtNum2.setText("");
    }
}