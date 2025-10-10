package com.example.p9u2_medinabeltrancarlosalberto;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;

public class MainActivity extends AppCompatActivity {
    private ImageView iv1, iv2, iv3;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        iv1 = findViewById(R.id.iv1);
        iv2 = findViewById(R.id.iv2);
        iv3 = findViewById(R.id.iv3);
    }

    public void inicio(View v){
        int valor1 = 1+(int)(Math.random());
        int valor2 = 1+(int)(Math.random());
        int valor3 = 1+(int)(Math.random());

        switch (valor1){
            case 0: iv1.setImageResource(R.drawable.uno);break;
            case 1: iv1.setImageResource(R.drawable.dos);break;
            case 2: iv1.setImageResource(R.drawable.tres);break;
            case 3: iv1.setImageResource(R.drawable.cuatro);break;
            case 4: iv1.setImageResource(R.drawable.cinco);break;
            case 5: iv1.setImageResource(R.drawable.seis);break;
        }

        switch (valor2){
            case 0: iv2.setImageResource(R.drawable.uno);break;
            case 1: iv2.setImageResource(R.drawable.dos);break;
            case 2: iv2.setImageResource(R.drawable.tres);break;
            case 3: iv2.setImageResource(R.drawable.cuatro);break;
            case 4: iv2.setImageResource(R.drawable.cinco);break;
            case 5: iv2.setImageResource(R.drawable.seis);break;
        }

        switch (valor3){
            case 0: iv3.setImageResource(R.drawable.uno);break;
            case 1: iv3.setImageResource(R.drawable.dos);break;
            case 2: iv3.setImageResource(R.drawable.tres);break;
            case 3: iv3.setImageResource(R.drawable.cuatro);break;
            case 4: iv3.setImageResource(R.drawable.cinco);break;
            case 5: iv3.setImageResource(R.drawable.seis);break;
        }
    }
}