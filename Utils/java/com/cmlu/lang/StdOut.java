package com.cmlu.lang;

import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.util.Locale;

/**
 * ��׼���
 * @author Administrator
 *
 */
public class StdOut {
	/**
	 * �����ļ��ı��뷽ʽ
	 */
	private static final String UTF8 = "UTF-8";
	
	/**
	 * �����ض��ĵ������κ��Ļ�����
	 */
	private static final Locale US_LOCALE = new Locale("en","US");
	
	/**
	 * ���
	 */
	private static PrintWriter out;
	
	/**
	 * ��̬��ʼ��
	 */
	static{
		try{
			out = new PrintWriter(new OutputStreamWriter(System.out,UTF8),true);
		}
		catch(Exception ex){
			System.out.println(ex);
		}
	}
	
	/**
	 * ����ʵ��
	 */
	private StdOut(){}
	
	/**
	 * �ر������
	 */
	public static void close(){
		if(out != null){
			out.close();
		}
	}
	
	/**
	 * ��ӡ����
	 */
	public static void println(){
		out.println();
	}
	
	/**
	 * ��ӡһ������
	 * @param x
	 */
	public static void println(Object obj){
		out.println(obj);
	}
	
	/**
	 * ����ַ���
	 * @param s
	 */
	public static void println(String s){
		out.println(s);
	}
	
	/**
	 * ��ӡbooleanֵ
	 * @param b
	 */
	public static void println(boolean b){
		out.println(b);
	}
	
	/**
	 * ���ַ���ӡ������̨
	 * @param c
	 */
	public static void println(char c){
		out.println(c);
	}
	
	/**
	 * ��ӡ������
	 * @param d
	 */
	public static void println(double d){
		out.println(d);
	}
	
	/**
	 * ��ӡ����ֵ
	 * @param x
	 */
	public static void println(float f){
		out.println(f);
	}
	
	/**
	 * ��ӡ����ֵ
	 * @param i
	 */
	public static void println(int i){
		out.println(i);
	}
	
	/**
	 * ��ӡ������ֵ
	 * @param l
	 */
	public static void println(long l){
		out.println(l);
	}
	
	/**
	 * ��ӡ������
	 * @param s
	 */
	public static void println(short s){
		out.println(s);
	}
	
	/**
	 * ��ӡ�ֽ�
	 * @param b
	 */
	public static  void println(byte b){
		out.println(b);
	}
	
	/**
	 * ��ӡ�����
	 */
	public static void print(){
		out.flush();
	}
	
	/**
	 * ��ӡ����
	 * @param obj
	 */
	public static void print(Object obj){
		out.print(obj);
		out.flush();
	}
	
	/**
	 * ��ӡ�ַ���
	 * @param s
	 */
	public static void print(String s){
		out.print(s);
		out.flush();
	}
	
	/**
	 * ��ӡbooleanֵ��
	 * @param b
	 */
	public static void print(boolean b){
		out.print(b);
		out.flush();
	}
	
	/**
	 * ��ӡ�ַ�
	 * @param ch
	 */
	public static void print(char ch){
		out.print(ch);
		out.flush();
	}
	
	/**
	 * ��ӡ������
	 * @param d
	 */
	public static void print(double d){
		out.print(d);
		out.flush();
	}
	
	/**
	 * ��ӡ������
	 * @param f
	 */
	public static void print(float f){
		out.print(f);
		out.flush();
	}
	
	/**
	 * ��ӡ����
	 * @param i
	 */
	public static void print(int i){
		out.print(i);
		out.flush();
	}
	
	/**
	 * ��ӡ������
	 * @param l
	 */
	public static void print(long l){
		out.print(l);
		out.flush();
	}
	
	/**
	 * ��ӡ������
	 * @param x
	 */
	public static void print(short x){
		out.print(x);
		out.flush();
	}
	
	/**
	 * ��ӡ�ֽ�
	 * @param b
	 */
	public static void print(byte b){
		out.print(b);
		out.flush();
	}
	
	/**
	 * ��ʽ���ַ���
	 */
	public static void printf(String format,Object... args){
		out.printf(US_LOCALE, format,args);
		out.flush();
	}
	
	/**
	 * ָ��������Ϣ��ʽ���ַ���
	 */
	public static void printf(Locale locale,String format,Object... args){
		out.printf(locale, format ,args);
		out.flush();
	}
	
	/**
	 * ��Ԫ����
	 * @param args
	 */
	public static void main(String[] args){
		StdOut.println("test");
		StdOut.println(18);
		StdOut.println(true);
		StdOut.printf("%.6f\n", 1.0/7.0);
	}
	
}
