import React from 'react'
import { StyleSheet, Platform, Image, Text, View } from 'react-native'
import { createSwitchNavigator, createAppContainer } from 'react-navigation'// import the different screens
import loading from './screens/Loading'
import signup from './screens/SignUp'
import login from './screens/Login'
import main from './screens/Main'// create our app's navigation stack
export default createAppContainer(createSwitchNavigator(
  {
    Loading: loading,
    SignUp: signup,
    Login: login,
    Main: main
  },
  {
    initialRouteName: 'SignUp'
  }
));
