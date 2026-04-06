#!/bin/bash
# Filename: cs
# Date: 2026-04-04/15:07:35
# Author: Sauro Mayaka 
# Version: 1.0
# Description: Script for creating new scripts and assigning permissions
# Options: 


current_date=$(date +%F/%T)
script_name="$1"
script_path="$HOME/.bin/$script_name"
# current_scriptname="$(echo $0 | cut -d '.' -f 2 | cut -d '/' -f 2)"
current_scriptname="$(basename $0)"


if [[ $# -ne 1 ]]; then
	#Checking if the user has provided the one script name as an argument
	printf "Usage: $current_scriptname [ Scriptname ]"
	exit 1
else
	#Terminating the script if the user tries to create a script with the same name as the current script
	if [[ -e $script_path ]]; then
		printf "The script with the name $script_name already exists."
		exit 1
	else
		#Asking for the script author's name from the user
		read -p "Enter the Author's Name : " script_author

		#Creating the script in the .bin directory
		printf "Creating script $script_name ... \n"
		touch $script_path
		sleep 3
		
		#Adding the header to the script
		printf "%b" "#!/bin/bash\n#: Filename: $script_name\n#: Date: $current_date\n#: Author: $script_author \n#: Version: 1.0\n#: Description: \n#: Options: \n\n">> $script_path

		#Asking for script desciption from the user
		read -p "Enter the script description : " script_description
		if [[ -n $script_description ]]; then
			#Adding the script description to the script
			sed -i "s/Description: /Description: $script_description/g" $script_path
		fi

		#Adding executable permissions to the script and opening it in the default editor
		printf "Assigning Executable permissions ... \n"
		sleep 2
		chmod 755 $script_path
		printf "Opening script in editor ... \n"
		sleep 2

		#Opening the script in the default editor
		$EDITOR +$ $script_path
		exit 0
	fi
fi