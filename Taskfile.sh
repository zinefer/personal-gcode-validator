#!/bin/bash

function build {
	dotnet publish -r win-x64 -p:PublishSingleFile=true
}

function help {
    echo "$0 <task> <args>"
    echo "Tasks:"
    compgen -A function | cat -n
}

TIMEFORMAT="Task completed in %3lR"
time ${@:-help}