echo "CHANGELOG"
echo ----------------------
git tag -l | sort -u -r | while read TAG ; do
    echo
    if [ $NEXT ];then
        echo [$NEXT]
    else
        echo "[Current]"
    fi
    GIT_PAGER=cat git log --no-merges --format=" * %s" $TAG..$NEXT
    NEXT=$TAG
done
FIRST=$(git tag -l | head -3)
echo
echo [$FIRST]
GIT_PAGER=cat git log --no-merges --format=" * %s" $FIRST

git log v2.1.0...v2.1.1 --pretty=format:'<li> <a href="https://github.com/komal-rathore-careerbuilder/NewTest.git/a02ccd7de9d19e2551a2192df5937efd363e47ef/%H">view a02ccd7de9d19e2551a2192df5937efd363e47ef &bull;</a> %s</li> ' --reverse | grep "#changelog"