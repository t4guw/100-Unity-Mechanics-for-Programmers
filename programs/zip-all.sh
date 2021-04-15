#!/bin/bash

# Will list all files in directory and create a zip file for each

ls -A1 | xargs -I % zip -r '%'.zip %
