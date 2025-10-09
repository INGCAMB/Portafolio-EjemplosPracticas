package com.example.practicamultimedia5;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.content.res.AssetFileDescriptor;
import android.net.Uri;
import android.net.UrlQuerySanitizer;
import android.os.Bundle;
import android.provider.MediaStore;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import android.widget.Toast;
import android.widget.VideoView;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class MainActivity extends AppCompatActivity {

    private static final int Toma_Video = 1;
    private VideoView vv;
    private Spinner sp;
    private String[] lista;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        vv = findViewById(R.id.VideoV);
        sp = findViewById(R.id.spinner);
        lista = fileList();
        ArrayAdapter<String> adapter = new ArrayAdapter<>(this, android.R.layout.simple_spinner_item,lista);
        sp.setAdapter(adapter);
    }

    public void tomarVideo(View view){
        Intent intent = new Intent(MediaStore.ACTION_VIDEO_CAPTURE);
        startActivityForResult(intent,Toma_Video);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == Toma_Video && resultCode==RESULT_OK){
            Uri videoUri = data.getData();
            vv.setVideoURI(videoUri);
            vv.start();
            try {
                AssetFileDescriptor videoAsset = getContentResolver().openAssetFileDescriptor(data.getData(), "r");
                FileInputStream in = videoAsset.createInputStream();
                FileOutputStream archivo = openFileOutput(crearNombreMP4(), Context.MODE_PRIVATE);
                byte[] buf = new byte[1024];
                int len;

                while((len = in.read(buf)) > 0){
                    archivo.write(buf, 0,len);
                }
            }
            catch (IOException e){
                Toast.makeText(this,"Problemas en la grabacion\n " + e.toString(),Toast.LENGTH_LONG).show();
            }
        }
    }

    private String crearNombreMP4() {
        String fecha = new SimpleDateFormat("yyyyMMDD_HHmmss").format(new Date());
        String nombre = fecha + ".mp4";
        return nombre;
    }

    public void verVideo(View view){
        int pos = sp.getSelectedItemPosition();
        vv.setVideoPath(getFilesDir()+"/"+lista[pos]);
        vv.start();
    }
}
