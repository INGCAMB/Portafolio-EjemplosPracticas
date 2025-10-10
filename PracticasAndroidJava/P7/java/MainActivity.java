/*Practica #7 Medina Beltran Carlos Alberto - 18212216
Alvarez Espinoza Raul

-Elaborar una programa convertidor de pesos a dólar y dólar a pesos.*/
package com.example.p7u2_medinabeltrancarlosalberto;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    private EditText num;
    private TextView txt3;
    private CheckBox check1, check2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        num= findViewById(R.id.txtnum);
        check1=findViewById(R.id.checkBox1);
        check2=findViewById(R.id.checkBox2);
        txt3=findViewById(R.id.textView3);
    }

    public void convertir(View v){
        double  dinero=Double.parseDouble(num.getText().toString());
        String resp="";
        if(check1.isChecked()){
            double dolares = dinero / 20.00;
            resp+="Dolares= $" + dolares;
        }
        if(check2.isChecked()){
            double pesos = dinero * 19.70;
            resp+="Pesos= $" + pesos;
        }
        if(check1.isChecked() && check2.isChecked()){
            resp = "";
            Toast.makeText(this, "No se pueden escoger las dos respuestas", Toast.LENGTH_SHORT).show();
        }
        txt3.setText(resp);
    }
}