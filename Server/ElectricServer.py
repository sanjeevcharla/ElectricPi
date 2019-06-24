from gpiozero import LED
from flask import Flask, render_template

app = Flask(__name__)

#Create pin to toggle the electronic relay
switchPin=LED(2)

"""
The connected LED is a common anode LED. 
Please toggle states based on LED type accordingly.
"""
#Switch Off device initially
switchPin.on()

#Welcome page for web UI
@app.route('/')        
def index():
        return render_template("index.html")

#URL for On and Off
#Please toggle state of the pin according to the device connected.
@app.route('/charging/<flag>')
def charging(flag):
        print(flag)
        if(flag=='1'):
                print('On device')
                switchPin.off()
        else:
                print('Off device')
                switchPin.on()
        return "Device status changed to {flag}".format(flag=flag)

#Run the app if not called from another module.
if __name__=='__main__':
        app.run(host='10.0.0.4',port=6789)

