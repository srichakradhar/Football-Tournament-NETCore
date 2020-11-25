#!/bin/sh
fuser -k 8001/tcp
count=1
cd FootBallTournament
dotnet run > server.txt 2>&1 &
pid=$!
while [ "$(cat server.txt | grep 'Application started. Press Ctrl+C to shut down.')" == "" ] && [ $count -lt 40 ]
do
sleep 1
count=$((count + 1))
done
cd ..
cd FootBallUnit.Tests
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:Exclude="[xunit*]\*" /p:CoverletOutput="./"
dotnet reportgenerator "-reports:coverage.cobertura.xml" "-targetdir:TestResults/html" -reporttypes:HTML
sleep 10
cd TestResults/html
test=$(ex +'%s/<[^>]\+>/ /g|%p' -scq! index.htm | awk '{print $6 "\t" $9}' | awk 'FNR ==53 {print $1}')
test1=$(ex +'%s/<[^>]\+>/ /g|%p' -scq! index.htm | awk '{print $6 "\t" $9}' | awk 'FNR ==54 {print $1}')
test2=$(ex +'%s/<[^>]\+>/ /g|%p' -scq! index.htm | awk '{print $6 "\t" $9}' | awk 'FNR ==55 {print $1}')
test3=$(ex +'%s/<[^>]\+>/ /g|%p' -scq! index.htm | awk '{print $6 "\t" $9}' | awk 'FNR ==56 {print $1}')
coverage=$(echo $test $test1 $test2 $test3 | awk '{print ($1+$2+$3+$4)/4}')
#echo $coverage
echo "FS_SCORE":$coverage%