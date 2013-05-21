package com.cmlu.lang;

import java.io.BufferedInputStream;
import java.io.File;
import java.io.InputStream;
import java.net.Socket;
import java.net.URL;
import java.net.URLConnection;
import java.util.Locale;
import java.util.Scanner;

/**
 * ��stdin,socket���ļ�����url�ж�ȡ����
 * @author Administrator
 *
 */
public final class In {
	
	/**
	 * ���Դ�������ʽ�������������ͺ��ַ����ļ��ı�ɨ�������ָ��Ĭ���ǿհ�
	 */
	private Scanner scanner;
	
	/**
	 * ʹ�õı��뷽ʽ�� ��UTF-8
	 */
	private String charsetName = "ISO-8859-1";
	
	/**
	 * ��־�ض��ĵ������κ��Ļ�����
	 */
	private Locale usLocale = new Locale("en", "US");
	//private Locale chLocale = Locale.CHINESE;
	
	/**
	 * Ĭ�ϵĹ��캯����Ĭ������Դ�Ǳ�׼��
	 */
	public In(){
		//charsetName��־�ֽ�ת��Ϊ�ַ��ķ�ʽ
		scanner = new Scanner(new BufferedInputStream(System.in),charsetName);
		//����ɨ��������Ϊָ�������Ի���
		scanner.useLocale(usLocale);
	}
	
	/**
	 * ��socket�л�ȡ������
	 * @param socket
	 * @throws Exception 
	 */
	public In(Socket socket) throws Exception{
		if(socket == null){
			throw new Exception("input parameter can not be null");
		}
		try{
			InputStream is = socket.getInputStream();
			scanner = new Scanner(new BufferedInputStream(is),charsetName);
			//����ɨ��������Ϊָ���Ļ���
			scanner.useLocale(usLocale);
		}
		catch (Exception e) {
			// TODO: handle exception
			System.err.println("Could not open socket,exception is "+e.toString());
		}
	}
	
	/**
	 * ��url�л�ȡ������
	 * @param url
	 */
	public In(URL url){
		try{
			URLConnection site = url.openConnection();
			InputStream is = site.getInputStream();
			scanner = new Scanner(new BufferedInputStream(is),charsetName);
			scanner.useLocale(usLocale);
		}
		catch (Exception e) {
			// TODO: handle exception
			System.err.println("exception :"+e.toString());
		}
	}
	
	/**
	 * ���ļ��л�ȡ������
	 * @param file
	 */
	public In(File file){
		try{
			scanner = new Scanner(file,charsetName);
			scanner.useLocale(usLocale);
		}
		catch (Exception e) {
			// TODO: handle exception
			System.err.println("exception:"+file);
		}
	}
	
	/**
	 * ���ļ�������ҳҳ���л�ȡ����
	 * @param s
	 */
	public In(String s){
		try{
			File file = new File(s);
			if(file.exists()){
				scanner = new Scanner(file,charsetName);
				scanner.useLocale(usLocale);
				return;
			}
			
			//������Ϊurl����
			URL url = getClass().getResource(s);
			if(url == null){
				url = new URL(s);
			}
			
			URLConnection site = url.openConnection();
			InputStream is = site.getInputStream();
			scanner = new Scanner(new BufferedInputStream(is),charsetName);
			scanner.useLocale(usLocale);
		}
		catch(Exception e){
			System.out.println("Exception:"+e.toString());
		}
		
	}

	/**
	 * �������Ƿ����
	 * @return
	 */
	public boolean exists(){
		return scanner != null;
	}
	
	/**
	 * �������Ƿ�Ϊ��
	 * @return
	 */
	public boolean isEmpty(){
		return !scanner.hasNext();
	}
	
	/**
	 * �Ƿ�����һ��
	 * @return
	 */
	public boolean hasNextLine(){
		return scanner.hasNextLine();
	}
	
	/**
	 * ���������ж�ȡ��һ��
	 * @return
	 */
	public String readLine(){
		String line;
		try{
			line = scanner.nextLine();
		}
		catch (Exception e) {
			// TODO: handle exception
			line = null;
		}
		return line;
	}
	
	
	/**
	 * ���������ж�ȡ��һ���ַ�
	 * @return
	 */
	public char readChar(){
		String s = scanner.findWithinHorizon("(?s).", 1);
		return s.charAt(0);
	}
	
	/**
	 * ��ȡ��������
	 * @return
	 */
	public String readAll(){
		if(!scanner.hasNextLine()){
			return null;
		}
		
		return scanner.useDelimiter("\\A").next();
	}
	
	/**
	 * ���������ж�ȡ��һ���ַ���
	 * @return
	 */
	public String readString(){
		return scanner.next();
	}
	
	/**
	 * ����һ���������ж�ȡ����
	 * @return
	 */
	public int readInt(){
		return scanner.nextInt();
	}
	
	/**
	 * ���������ж�ȡ��һ��double
	 * @return
	 */
	public double readDouble(){
		return scanner.nextDouble();
	}
	
	/**
	 * ���������ж�ȡ��һ��������
	 * @return
	 */
	public float readFloat(){
		return scanner.nextFloat();
	}
	
	/**
	 * ��ȡ��һ��������
	 * @return
	 */
	public long readLong(){
		return scanner.nextLong();
	}
	
	/**
	 * ��ȡ��һ���ֽ�
	 * @return
	 */
	public byte readByte(){
		return scanner.nextByte();
	}
	
	/**
	 * ���������ж�ȡһ�У������ true����1���򷵻�true�������false����0�򷵻�false
	 * @return
	 */
	public boolean readBoolean(){
		String s = readString();
		if(s.equalsIgnoreCase("true")){
			return true;
		}
		if(s.equalsIgnoreCase("false")){
			return false;
		}
		if(s.equalsIgnoreCase("1")){
			return true;
		}
		if(s.equalsIgnoreCase("0")){
			return false;
		}
		throw new java.util.InputMismatchException();
	}

	/**
	 * read ints from file
	 * @param filename
	 * @return
	 */
	public static int[] readInts(String filename){
		In in = new In(filename);
		String[] fields = in.readAll().trim().split("\\s+");
		int[] vals = new int[fields.length];
		for(int i=0;i<fields.length;i++){
			vals[i] = Integer.parseInt(fields[i]);
		}
		return vals;
	}
	
	/**
	 * ���ļ��ж�ȡdouble
	 * @param filename
	 * @return
	 */
	public static double[] readDoubles(String filename){
		In in = new In(filename);
		String[] fields = in.readAll().trim().split("\\s+");
		double[] vals = new double[fields.length];
		for(int i=0;i<fields.length;i++){
			vals[i] = Double.parseDouble(fields[i]);
		}
		return vals;
	}

	/**
	 * ���ļ��ж�ȡ�ַ���
	 * @param filename
	 * @return
	 */
	public static String[] readStrings(String filename){
		In in = new In(filename);
		String[] fields = in.readAll().trim().split("\\s+");
		return fields;
	}


	/**
	 * �ر�������
	 */
	public void close(){
		if(scanner != null){
			scanner.close();
		}
	}
	
	/**
	 * ���Կͻ���
	 * @param args
	 */
	public static void main(String[] args){
		In in;
		String urlName = "http://introcs.cs.princeton.edu/stdlib/InTest.txt";
		System.out.println("readAll() from URL "+urlName);
		System.out.println("-----------------------------------------------------");
		try{
			in = new In(urlName);
			System.out.println(in.readAll());
		}
		catch(Exception ex){
			System.out.println(ex);
		}
		
		System.out.println();
		
	}
	
	
	
	
}
