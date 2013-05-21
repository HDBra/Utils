package io;

import java.util.regex.*;
import java.io.*;
import java.util.*;

public class Directory {
	/**
	 * ����ָ��Ŀ¼�µ��ļ��������ݹ���Ŀ¼�µ��ļ�
	 * ������ļ�����Ŀ¼
	 */
	public static File[] local(File dir,final String regex){
		return dir.listFiles(new FilenameFilter() {
			private Pattern pattern = Pattern.compile(regex);
			@Override
			public boolean accept(File dir, String name) {
				// TODO Auto-generated method stub
				return pattern.matcher(new File(name).getName()).matches();
			}
		});
	}
	
	/**
	 * ����ָ��Ŀ¼�µ��ļ��������ݹ���Ŀ¼�µ��ļ�
	 * ������ļ�����Ŀ¼
	 */
	public static File[] local(String path,final String regex){
		return local(new File(path), regex);
	}
	
	/**
	 * Ŀ¼�µ��ļ���Ŀ¼��Ϣ
	 * @author Administrator
	 *
	 */
	public static class TreeInfo implements Iterable<File>{

		public List<File> files = new ArrayList<File>();
		public List<File> dirs = new ArrayList<File>();
		@Override
		public Iterator<File> iterator() {
			// TODO Auto-generated method stub
			return files.iterator();
		}
		
		public void addAll(TreeInfo other){
			files.addAll(other.files);
			dirs.addAll(other.dirs);
		}
	}
	
	public static TreeInfo walk(String start, String regex){
		return recurseDirs(new File(start),regex);
	}
	
	public static TreeInfo walk(File start,String regex){
		return recurseDirs(start,regex);
	}
	
	/**
	 * ���صݹ�Ŀ¼
	 * @param start
	 * @return
	 */
	public static TreeInfo walk(File start){
		return recurseDirs(start,".*");
	}
	
	public static TreeInfo walk(String start){
		return recurseDirs(new File(start),".*");
	}
	
	public static TreeInfo recurseDirs(File startDir,String regex){
		TreeInfo resultInfo = new TreeInfo();
		for(File item:startDir.listFiles()){
			if(item.isDirectory()){
				resultInfo.dirs.add(item);
				resultInfo.addAll(recurseDirs(item, regex));
			}
			else{
				if(item.getName().matches(regex)){
					resultInfo.files.add(item);
				}
			}
		}
		return resultInfo;
	}
	
}
