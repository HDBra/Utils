package com.cmlu.lang;

import java.io.BufferedInputStream;
import java.util.Locale;
import java.util.Scanner;

/**
 * �ӱ�׼���ж�ȡ�ַ���������
 * @author Administrator
 *
 */
public final class StdIn {

	/**
	 * ָ�����뷽ʽ
	 */
	private static String charsetName="UTF-8";
	
	/**
	 * �����ض��ĵ������κ��Ļ�����
	 */
	private static Locale usLocale = new Locale("en","US");
	
	/**
	 * ����ɨ��������
	 */
	private static Scanner scanner = new Scanner(new BufferedInputStream(System.in),charsetName);
	
	/**
	 * ��̬��ʼ��
	 */
	static{
		scanner.useLocale(usLocale);
	}
	
	/**
	 * ˽�й��캯��      ����
	 */
	private StdIn(){
	}
	
	/**
	 * �ж����������Ƿ�ֻ�пհ׷�
	 * @return
	 */
	public static boolean isEmpty(){
		return !scanner.hasNext();
	}
	
	/**
	 * �ӱ�׼�������ж�ȡ��һ��
	 * @return
	 */
	public static String readString(){
		return scanner.next();
	}
	
	/**
	 * �ӱ�׼�������ж�ȡ��һ������
	 * @return
	 */
	public static int readInt(){
		return scanner.nextInt();
	}
	
	/**
	 * �ӱ�׼�����з�����һ��double
	 * @return
	 */
	public static double readDouble(){
		return scanner.nextDouble();
	}
	
	/**
	 * �ӱ�׼�����ж�ȡ��һ��������
	 * @return
	 */
	public static float readFloat(){
		return scanner.nextFloat();
	}
	
	/**
	 * �ӱ�׼�������ж�ȡ��һ��������
	 * @return
	 */
	public static short readShort(){
		return scanner.nextShort();
	}
	
	/**
	 * �ӱ�׼�����ж�ȡ������
	 * @return
	 */
	public static long readLong(){
		return scanner.nextLong();
	}
	
	/**
	 * �ӱ�׼�����ж�ȡ��һ���ֽ�
	 * @return
	 */
	public static byte readByte(){
		return scanner.nextByte();
	}
	
	/**
	 * �ӱ�׼���ж�ȡ���ݣ�������ת��Ϊboolean���ͣ�true��1ת��Ϊtrue��false��0ת��Ϊfalse
	 * @return
	 */
	public static boolean readBoolean(){
		String s = readString();
		
		if(s.equalsIgnoreCase("true") || s.equalsIgnoreCase("1")){
			return true;
		}
		if(s.equalsIgnoreCase("false") || s.equalsIgnoreCase("0")){
			return false;
		}
		throw new java.util.InputMismatchException();
	}
	
	/**
	 * �жϱ�׼�����Ƿ�����һ��
	 * @return
	 */
	public static boolean hasNextLine(){
		return scanner.hasNextLine();
	}
	
	/**
	 * ���������ж�ȡ��һ��
	 * @return
	 */
	public static String readLine(){
		return scanner.nextLine();
	}
	
	/**
	 * ���������ж�ȡ��һ���ַ�
	 * @return
	 */
	public static char readChar(){
		String s = scanner.findWithinHorizon("(?s).", 1);
		return s.charAt(0);
	}
	
	/**
	 * �ӱ�׼�����л�ȡ��������
	 * @return
	 */
	public static String readAll(){
		if(!scanner.hasNextLine()){
			return null;
		}
		
		return scanner.useDelimiter("\\A").next();
	}
	
	/**
	 * ���������ж�ȡint����
	 * @return
	 */
	public static int[] readInts(){
		String[] fields = readAll().trim().split("\\s+");
		int[] vals = new int[fields.length];
		for(int i=0;i<fields.length;i++){
			vals[i] = Integer.parseInt(fields[i]);
		}
		return vals;
	}
	
	public static double[] readDoubles(){
		String[] fields = readAll().trim().split("\\s+");
		double[] vals = new double[fields.length];
		for(int i=0;i<fields.length;i++){
			vals[i] = Double.parseDouble(fields[i]);
		}
		return vals;
	}
	
	/**
	 * ���������ж�ȡ���е��ַ���
	 * @return
	 */
	public static String[] readStrings(){
		String[] fields =readAll().trim().split("\\s+");
		return fields;
	}
	
	/**
	 * ��Ԫ����
	 * @param args
	 */
	public static void main(String[] args){
		System.out.println("Type a string:");
		String string = StdIn.readString();
		System.out.println("Your string was: "+string);
		System.out.println();
		
		System.out.println("Type an int: ");
		int a = StdIn.readInt();
		System.out.println("Your int was: "+a);
		System.out.println();
		
		System.out.println("Type a boolean:");
		boolean b = StdIn.readBoolean();
		System.out.println("Your boolean was: "+ b);
		System.out.println();
		
		System.out.println("Type a double: ");
		double d = StdIn.readDouble();
		System.out.println("your double was: "+d);
		System.out.println();
	}
	
}
