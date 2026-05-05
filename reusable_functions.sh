#!/bin/bash
#: Filename: reusable_functions.sh
#: Date: 2026-04-20/13:23:24
#: Author: Sauro Mayaka 
#: Version: 1.0
#: Description: These are functions that can be reused in various scripts.
#: Options: 


loading() {
    message=$1
    tput civis
    trap "tput cnorm; exit" INT TERM EXIT
    printf "%s" "$message"
    sleep .5
    for i in {1..3}; do
        printf "."
        sleep 1
    done
    sleep .5
    tput cnorm
    printf "\n"
}
