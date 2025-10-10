/*Practica #4 Medina Beltran Carlos Alberto - 18212216

-Elaborar una aplicacion para utilizar switch, activando y desactivando datos moviles o cuando
el wifi esta desactivado*/
package com.example.p4u2_medinabeltrancarlosalberto;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.os.Bundle;
import android.view.View;
import android.widget.Switch;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    private Switch switch1, switch2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        switch1=findViewById(R.id.switch1);
        switch2=findViewById(R.id.switch2);
    }

    public void verifica(View v){
        Context context = getApplicationContext();
        if(switch1.isChecked()){
            Toast.makeText(context, "Datos moviles activos", Toast.LENGTH_SHORT).show();
        }else if(switch2.isChecked()){
            Toast.makeText(context, "Datos moviles desactivos", Toast.LENGTH_SHORT).show();
        }else{
            Toast.makeText(context, "Wifi desactivo", Toast.LENGTH_SHORT).show();
        }
    }
}