package com.example.practicamultimedia1;

import androidx.appcompat.app.AppCompatActivity;
import android.media.MediaPlayer;
import android.os.Bundle;
import android.view.View;
import android.widget.Switch;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {
    MediaPlayer mp;
    TextView tv;
    Switch s;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        tv = findViewById(R.id.txt);
        s = findViewById(R.id.swtCiclo);
    }

    @Override
    protected void onStop() {
        super.onStop();
        if (mp != null){
            mp.release();
            mp = null;
        }
    }
    public  void start(View view){
        if (mp != null)
            mp.release();
        mp = MediaPlayer.create(this,R.raw.song1);
        if (s.isChecked())
            mp.setLooping(true);
        mp.start();
        tv.setText("En reproduccion");
        mp.setOnCompletionListener(new MediaPlayer.OnCompletionListener() {
            @Override
            public void onCompletion(MediaPlayer mediaPlayer) {
                tv.setText("Detenida");
            }
        });
    }
    public void pause(View view){
        if (mp != null && mp.isPlaying()){
            mp.pause();
            tv.setText("En pausa");
        }
    }
    public void continueRS(View view){
        if (mp != null && !mp.isPlaying()){
            mp.start();
            tv.setText("En reproduccion");
        }
    }
    public void advance(View view){
        if (mp != null){
            int position = mp.getCurrentPosition();
            mp.seekTo(position+5000);
        }
    }
    public void cycle(View view){
        if (s.isChecked())
            mp.setLooping(true);
        else
            mp.setLooping(false);

    }
}
