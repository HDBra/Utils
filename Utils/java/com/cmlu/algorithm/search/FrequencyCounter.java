package com.cmlu.algorithm.search;

import com.cmlu.lang.StdIn;
import com.cmlu.lang.StdOut;

/**
 * ͳ�Ƹ�����ֵ���ֵĴ���
 * @author Administrator
 *
 */
public class FrequencyCounter {

    
    public static void main(String[] args){
	/*//�ֵ��в�ͬ��Ԫ�������ܵ�Ԫ����
	int distinct = 0,words = 0;
	int minlen = Integer.parseInt(args[0]);
	ST<String, Integer> st = new ST<String,Integer>();
	
	//������ֵ�Ƶ��
	while(!StdIn.isEmpty()){
	    String key = StdIn.readString();
	    //С����С���ȵ�ɾ��
	    if(key.length() < minlen) continue;
	    
	    words++;
	    if(st.contains(key)){
		st.put(key,st.get(key)+1);
	    }
	    else{
		st.put(key,1);
		distinct++;
	    }
	}
	
	//�ҵ����ִ������
	String max = "";
	st.put(max,0);
	for(String word:st.keys()){
	    if(st.get(word)>st.get(max)){
		max = word;
	    }
	}
	
	
	StdOut.println(max + " " + st.get(max));
        StdOut.println("distinct = " + distinct);
        StdOut.println("words  = " + words);*/
    }
    
    
}
