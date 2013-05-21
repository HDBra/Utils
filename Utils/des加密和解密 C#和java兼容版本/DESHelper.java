package com.cmlu.common;

import java.security.Key;
import java.security.spec.AlgorithmParameterSpec;

import javax.crypto.Cipher;
import javax.crypto.SecretKeyFactory;
import javax.crypto.spec.DESKeySpec;
import javax.crypto.spec.IvParameterSpec;

/**
 * des������
 * @author Administrator
 *
 */
public class DESHelper{
public static final String ALGORITHM_DES = "DES/CBC/PKCS5Padding";
    
    /**
     * DES�㷨 �� ����
     * @param key  �����س� ���Ȳ�С��8λ
     * @param data �������ַ���
     * @return
     * @throws Exception
     */
    public static String encode(String key,String data) throws Exception{
	return encode(key, data.getBytes("UTF-8"));
    }
    
    /**
     * DES�㷨������
     * @param key ������Կ�� ����Ϊ8λ
     * @param data �������ַ���
     * @return
     * @throws Exception
     */
    private static String encode(String key,byte[] data) throws Exception{
      	DESKeySpec dks = new DESKeySpec(key.getBytes("ASCII"));
      	SecretKeyFactory keyFactory = SecretKeyFactory.getInstance("DES");
      	Key secretKey = keyFactory.generateSecret(dks);
      	Cipher cipher = Cipher.getInstance(ALGORITHM_DES);
      	IvParameterSpec iv = new IvParameterSpec(key.getBytes("ASCII"));
      	AlgorithmParameterSpec parameterSpec = iv;
      	cipher.init(Cipher.ENCRYPT_MODE, secretKey,parameterSpec);
      	byte[] bytes = cipher.doFinal(data);
      	short[] array = new short[bytes.length];
      	for(int i=0;i<bytes.length;i++){
      	    if(bytes[i]<0){
      		array[i] = (short)(256+bytes[i]);
      	    }
      	    else {
		array[i] = bytes[i];
	    }
      	}
      	StringBuilder sb = new StringBuilder();
      	for(short s:array){
      	    sb.append(String.format("%02X", s));
      	}
	return sb.toString();
    }
    

    /**
     * DES�㷨������
     * @param key  ������Կ�� ����Ϊ8λ
     * @param data �����ܵ��ַ���
     * @return
     */
    public static String decode(String key,String data) throws Exception{
	byte[] bytes = new byte[data.length()/2];
	for(int i=0;i<data.length()/2;i++){
	    int x = Integer.parseInt(data.substring(i*2,i*2+2),16);
	    bytes[i] = (byte)x;
	}
	return decode(key, bytes);
    }
    
    /**
     * DES�㷨������
     * @param key
     * @param data
     * @return
     * @throws Exception
     */
    private static String decode(String key,byte[] data) throws Exception{
	DESKeySpec dks = new DESKeySpec(key.getBytes("ASCII"));
	SecretKeyFactory keyFactory = SecretKeyFactory.getInstance("DES");
	Key secretKey = keyFactory.generateSecret(dks);
	Cipher cipher = Cipher.getInstance(ALGORITHM_DES);
	IvParameterSpec iv = new IvParameterSpec(key.getBytes("ASCII"));
	AlgorithmParameterSpec paramSpec = iv;
	cipher.init(Cipher.DECRYPT_MODE, secretKey,paramSpec);

	String result = new String(cipher.doFinal(data), "utf-8");
	return result;
    }
}