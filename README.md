# This is a demo project in C#/.Net for a desktop front-end application.

## **Auth Page**

This page is connected with OAuth2 from Whop which allows us to authenticate users with a unique key given at checkout.

![alt text](https://media.discordapp.net/attachments/997170800467644480/1130417394553213019/Auth.JPG)

## **Dashboard**

The dashboard is the default page once a user is authenticated. it contains a graph that shows users the success over time. Alongside more analytics.
it also contains a list of items that users have checked out in the past.

With the default page users can also see access to another page on the left Nav bar. At the bottom, we update the checker along with the user's name and their discord userid and Avatar.

![alt text](https://media.discordapp.net/attachments/997170800467644480/1130417394796462130/Dash.JPG?width=810&height=417)

## **Task**

This page contains few buttons and the rest of it holds any task created. All the tasks can be right-clicked to perform quick action or can be selected in bulk and performed as a mass action.

Clicking New or Edit will pop up a new page that is used to create a new task.

![alt text](https://media.discordapp.net/attachments/997170800467644480/1130417396205768724/Task.JPG?width=810&height=416)

## **Profiles**

This page contains sections where users can input all their info and a profile is created at the bottom bar. This bar is scrollable and clicking on one will populate the info above.

Users can also import or export the profiles as needed.

![alt text](https://media.discordapp.net/attachments/997170800467644480/1130417395039744030/Profile.JPG?width=810&height=417)

## **Proxies**

This page contains a blank canvas for displaying all the proxies. Also a dropdown list of proxies.

![alt text](https://media.discordapp.net/attachments/997170800467644480/1130417395454988409/Proxies.JPG?width=810&height=417)

## **Settings**

This page is where all the users can change the settings as desired once a setting is set it is always displayed on initialization. It also contains an option for the user to detach the key from the current device.

![alt text](https://media.discordapp.net/attachments/997170800467644480/1130417395752775690/settings.JPG?width=810&height=417)

## **Other features:**

Auto self updater
Custom close minimize expand buttons.
All the proxies/profiles and other info are stored in AppData and accessed through environment variables.
Each key is allowed once per machine hence an HWID is used on the first login to the application and checked every 5 minutes to validate authenticity.
Made from scratch.

**All the contents of the application are properties of SoledOutConnect Ltd.**
