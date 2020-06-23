//+------------------------------------------------------------------+
//|                                                 daratechtest.mq5 |
//|                        Copyright 2020, MetaQuotes Software Corp. |
//|                                             https://www.mql5.com |
//+------------------------------------------------------------------+
#property copyright "Copyright 2020, MetaQuotes Software Corp."
#property link      "https://www.mql5.com"
#property version   "1.00"
#include <JAson.mqh>
//+------------------------------------------------------------------+
//| Expert initialization function                                   |
//+------------------------------------------------------------------+

char post[];
char result[];
string cookie=NULL,headers;
string url = "";
//string url="http://127.0.0.1:5000/MetaTrader/SaveCandles/";
//string url="http://127.0.0.1:9090/send_data/";
void SendData(string strpost);

MqlTick last_tick;
int stotal;
int sindex;
string sname;
char data[];  

void SendData(string strpost)
   {
      ResetLastError();
      ArrayResize(post,StringLen(strpost));
      
      for(int i=0; i<StringLen(strpost); i++)
      {
         post[i]=strpost[i];
      }
      int res = WebRequest("POST", url, cookie, NULL,  500, post, 0, result, headers);

   }
   
int OnInit()
  {
   return(INIT_SUCCEEDED);
  }

void OnDeinit(const int reason)
  {
      EventKillTimer();
  }

void OnTick()
  {
//---
   
   
   //Open = iOpen(NULL,PERIOD_M5,0); 
   //High = iHigh(NULL, PERIOD_M5,0);
   //Low = iLow(NULL, PERIOD_M5,0);
   //Close = iClose(NULL, PERIOD_M5,0); 
   //Time = iTime(NULL, PERIOD_M5,0);
   
   CJAVal jv;
   //jv["open"]= iOpen(NULL,PERIOD_M5,0);
   //jv["high"]= iHigh(NULL, PERIOD_M5,0);
   //jv["low"]= iLow(NULL, PERIOD_M5,0);
   //jv["close"]= iClose(NULL, PERIOD_M5,0);  
   //jv["date"]=TimeToString(iTime(NULL,PERIOD_M5,0));
   //jv["symbol"]=SymbolName();
  
      
   //char data[]; 
   //ArrayResize(data, StringToCharArray(jv.Serialize(), data, 0, WHOLE_ARRAY)-1);
    
  // char data[];
   //string res_headers=NULL;
   
    //url = "http://127.0.0.1:5000/MetaTrader/SaveCandles/" + jv.Serialize(); 
   //int r = WebRequest("POST", url,"Content-Type: application/json\r\n", 5000, data, res_data, headers); 
   
   //string url="http://127.0.0.1:5000/MetaTrader/SaveCandles/" + jv.Serialize();
   int r =  WebRequest("POST", url, cookie, NULL,  500, data, 0, result, headers);  

   int stotal = SymbolsTotal(false);
   for(sindex = 0; sindex < stotal; sindex++)
   {
      sname = SymbolName(sindex, false);    
      if(SymbolInfoTick(sname,last_tick))
      {   
         jv["open"]= iOpen(sname,PERIOD_M5,0);
         jv["high"]= iHigh(sname, PERIOD_M5,0);
         jv["low"]= iLow(sname, PERIOD_M5,0);
         jv["close"]= iClose(sname, PERIOD_M5,0);  
         jv["date"]=TimeToString(iTime(sname,PERIOD_M5,0));
         jv["symbol"]=sname;
          
         url = "http://127.0.0.1:5000/MetaTrader/SaveCandles/" + jv.Serialize();
            
         int r =  WebRequest("POST", url, cookie, NULL,  500, data, 0, result, headers);  
         //SendData(last_tick.time+";"+sname+";"+last_tick.bid+";"+last_tick.ask+";"+last_tick.volume);
      }else 
        Print("SymbolInfoTick() failed, error = ",GetLastError());
    }
   
  }
