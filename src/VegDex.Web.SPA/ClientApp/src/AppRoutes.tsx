import {Counter} from "./components/Counter";
import {FetchData} from "./components/FetchData";
import {Home} from "./components/Home";
import {Blog} from "./components/Blog";
import React from "react";
import {About} from "./components/About";
import {Links} from "./components/Links";
import {Restaurants} from "./components/Restaurants";
import {Shopping} from "./components/Shopping";

const AppRoutes = [
  {
    index: true,
    element: <Home/>
  },
  {
    path: '/about',
    element: <About/>
  },
  {
    path: '/blog',
    element: <Blog/>
  },
  {
    path: '/links',
    element: <Links/>
  },
  {
    path: '/restaurants',
    element: <Restaurants/>
  },
  {
    path: '/shopping',
    element: <Shopping/>
  },
  {
    path: '/counter',
    element: <Counter/>
  },
  {
    path: '/fetch-data',
    element: <FetchData/>
  }
];

export default AppRoutes;
