package com.cmlu.algorithm.string;

import java.util.Arrays;

/**
 * Key indexed counting uses 8N + 3R + 1 array access to sort N items whose keys are integers between 0 and R-1
 * @author Administrator
 *
 */
public class KeyIndexdSort {

    private Item[] items;
    private int[] count;
    
    public KeyIndexdSort(Item[] items,int R){
	this.items = items;
	//֮���Լ�1����Ϊcount[i+1]����ʾkey i���ֵĴ�����ʹcount[0] = 0
	count = new int[R+1];
    }
    
    public void sort(){
	//��һ������ÿ��key���ֵ�Ƶ��
	for(int i=0;i<items.length;i++){
	    count[items[i].key+1]++;
	}
	//����ÿ��key�������������ʵλ��
	for(int i=0;i<count.length-1;i++){
	    count[i+1] += count[i];
	}
	//�����ݷŵ���������
	Item[] aux = new Item[items.length];
	for(int i=0;i<items.length;i++){
	    aux[count[items[i].key]++] = items[i];
	}
	//���ƻ�ԭ����
	for(int i=0;i<items.length;i++){
	    items[i] = aux[i];
	}
    }
}

class Item{
    public int key;
    //�����֮��ϵ��ʵ�ʵ�ֵ
    public String actualValue;
}