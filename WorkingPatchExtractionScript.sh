	
#Below commands are necessary for patch logic
New_tag="Pre-Prod_V_1.2.28_17_2"                                                                                               # initialize variable for new tag
Previous_tag="Pre-Prod_V_1.2.28_17_1"                                                                                        # initialize variable for old tag
mkdir -p "D:\Harbinger\Patches\2019\Patch "$(date +"%F")""
a="D:/WT/"
destination1="D:/Harbinger/Patches/2019/Patch $(date +"%F")"
touch "$a/file.txt"
touch "$destination1/file.txt"
git log --reverse  $New_tag ^$Previous_tag --pretty=format:'%h' > commits.txt

while read c
do
	echo "Current commit is: $c"
	git show $c --name-only --diff-filter=ACMRTUXB --pretty=format: >> file.txt                              # write a path of total files that changes in a commit in a file.txt    
    sort "file.txt" |uniq |tee "file.txt"
	if [ -z file.txt ]                                                                                       # check if file empty or not
	then
		echo "\$files is empty"
	else		
		while read line
        do		
		   source="$a$line"	   
		   destination2="$destination1/$line"
		   path=$( echo ${destination2%/*} )                                                                # extract a path without filename				   
		    if [ -f "$source" ]                                                                             # check for file exist
            then 			
				mkdir -p "$path"				                                                            # make directory
				cp "$source" "$path"	                                                                    # copy files from source to destination  
                echo "$line" >> "$destination1\file.txt"		
            fi            		
        done < file.txt	   
	fi	
done < commits.txt                                                  
rm commits.txt
rm file.txt
sort "$destination1\file.txt" |uniq |tee "$destination1\file.txt"
touch "$destination1/deployment-details.txt"                                                                # create file if it is not exist

git log --reverse  $New_tag ^$Previous_tag --pretty=format:"%s%x09%an%x09%h%x09%ad" --no-merges --date=relative > deployment-details.txt

#logic for copy deployment-details.txt instead of manual copy of that file

File="$a/deployment-details.txt"
if test -f $File; then
    cp $File "$destination1/deployment-details.txt"
	echo "file is present"
else
    echo "file is not present"
fi
	   



	
	
	