package com.example.practicamultimedia2;

import androidx.appcompat.app.AppCompatActivity;
import android.media.MediaPlayer;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    Button boton0,boton1;
    TextView tv1;
    MediaPlayer mp1;
    String numeroRecordar;                //  "01111"
    String numeroJugador;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        boton0=findViewById(R.id.btnCero);
        boton1=findViewById(R.id.btnUno);
        tv1=findViewById(R.id.TextV);
        desactivarBotones();
    }
    private void desactivarBotones() {
        boton0.setEnabled(false);
        boton1.setEnabled(false);
    }

    private void activarBotones() {
        boton0.setEnabled(true);
        boton1.setEnabled(true);
    }

    public void iniciarJuego(View v)
    {
        desactivarBotones();
        numeroRecordar="";
        agregarUnNumeroAlFinal();
        tv1.setText("Cantidad de cifras a recordar:"+numeroRecordar.length());
        numeroJugador="";
        emitirSonido(0);
    }

    private void emitirSonido(int posicion) {
        if (mp1!=null)
            mp1.release();
        if(numeroRecordar.charAt(posicion)=='0')
            mp1=MediaPlayer.create(this,R.raw.cero);
        if(numeroRecordar.charAt(posicion)=='1')
            mp1=MediaPlayer.create(this,R.raw.uno);
        mp1.start();
        mp1.setOnCompletionListener(new MediaPlayer.OnCompletionListener() {
            @Override
            public void onCompletion(MediaPlayer mp) {
                if (posicion<numeroRecordar.length()-1)
                {
                    emitirSonido(posicion+1);
                }
                else
                    activarBotones();
            }
        });

    }

    private void agregarUnNumeroAlFinal() {
        int ale=(int)(Math.random()*2);
        switch (ale) {
            case 0:
                numeroRecordar = numeroRecordar + "0";
                break;
            case 1:
                numeroRecordar = numeroRecordar + "1";
                break;
        }
    }

    public void presionBoton0(View v)
    {
        numeroJugador=numeroJugador+"0";
        controlarSiEsCorrecto();
    }

    public void presionBoton1(View v)
    {
        numeroJugador=numeroJugador+"1";
        controlarSiEsCorrecto();
    }

    private void controlarSiEsCorrecto() {
        if (numeroJugador.charAt(numeroJugador.length()-1)!=numeroRecordar.charAt(numeroJugador.length()-1))
        {
            Toast.makeText(this,"Perdiste",Toast.LENGTH_LONG).show();
            desactivarBotones();
        }
        else
        if (numeroJugador.length()==numeroRecordar.length())
        {
            desactivarBotones();
            numeroJugador="";
            agregarUnNumeroAlFinal();
            emitirSonido(0);
            tv1.setText("Cantidad de cifras a recordar:"+numeroRecordar.length());
        }
    }

    @Override
    protected void onStop() {
        super.onStop();
        if (mp1!=null)
        {
            mp1.release();
            mp1=null;
        }
    }
}
