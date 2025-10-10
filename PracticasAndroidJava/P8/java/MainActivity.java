/*Practica #8 Medina Beltran Carlos Alberto - 18212216
Alvarez Espinoza Raul

-Solo como recomendación pueden usar la estructura Switch en java y recibir la opcion y cantidad
de combos para resolver lo siguiente en un programa.*/
package com.example.p8u2_medinabeltrancarlosalberto;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    private EditText opc, cant;
    private TextView txt6;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        opc= findViewById(R.id.txtopcion);
        cant= findViewById(R.id.txtcantidad);
        txt6=findViewById(R.id.textView6);
    }

    public void cuenta(View v){
        String opcion = opc.getText().toString();
        double cantidad = Double.parseDouble(cant.getText().toString());
        String resp="";
        double total;
        switch (opcion)
        {
            case "A":
                total = (cantidad * 150) * 1.16;
                resp+="Total= $" + total + " Hambuerguesa de carne, papas y soda.";
                break;
            case "B":
                total = (cantidad * 120) * 1.16;
                resp+="Total= $" + total + " Hambuerguesa de pollo, papas y soda.";
                break;
            case "C":
                total = (cantidad * 100) * 1.16;
                resp+="Total= $" + total + " Hambuerguesa vegetariana y te natural.";
                break;
            case "D":
                total = (cantidad * 0) * 1.16;
                resp+="Total= $" + total + " Opción no registrada.";
                break;
            default:
                break;
        }
        txt6.setText(resp);
    }
}