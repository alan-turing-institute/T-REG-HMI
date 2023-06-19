#!/bin/sh
gunzip T-REG-HMI/Build/*.gz
sed 's/.gz//g' T-REG-HMI/index.html > tempfile
mv tempfile  T-REG-HMI/index.html
