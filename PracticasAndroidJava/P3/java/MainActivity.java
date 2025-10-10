/*Practica #3 Medina Beltran Carlos Alberto - 18212216

-Elaborar una aplicacion para utilizar checkbox, uno para sumar y otro  para opcion de restar dos
numeros*/
package com.example.p3u2_medinabeltrancarlosalberto;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {
    private EditText num1,num2;
    private TextView txt1;
    private CheckBox check1, check2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        num1= findViewById(R.id.txtnum1);
        num2= findViewById(R.id.txtnum2);
        check1=findViewById(R.id.checkBox1);
        check2=findViewById(R.id.checkBox2);
        txt1=findViewById(R.id.textView1);
    }

    public void operar(View v){
        int  n1=Integer.parseInt(num1.getText().toString());
        int  n2=Integer.parseInt(num2.getText().toString());
        String resp="";
        if(check1.isChecked()){
            int suma= n1+n2;
            resp+="La suma es="+suma;
        }
        if(check2.isChecked()){
            int resta= n1-n2;
            resp+="La resta es="+resta;
        }
        txt1.setText(resp);
    }
}