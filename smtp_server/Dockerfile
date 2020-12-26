FROM python:3

# Copy requirements and source code
COPY /requirements.txt /requirements.txt
COPY . .

# Install requirements
RUN pip3 install -r //requirements.txt

# Expose ports
EXPOSE 11125/tcp

# Start application
CMD ["python3", "__main__.py" ]
