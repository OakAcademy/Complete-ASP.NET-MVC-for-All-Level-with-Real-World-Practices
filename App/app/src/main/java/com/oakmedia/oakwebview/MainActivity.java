package com.oakmedia.oakwebview;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.webkit.WebView;
import android.webkit.WebViewClient;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        WebView url=(WebView)findViewById(R.id.oak);
        url.getSettings().setJavaScriptEnabled(true);
        url.setWebViewClient(new WebViewClient());
        url.loadUrl("http://www.mvctechnologymania.com/");
    }
}