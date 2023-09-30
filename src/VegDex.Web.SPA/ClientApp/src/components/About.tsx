import React, {useEffect, useState} from "react";
import {IPageInfo} from "../models/IPageInfo";
import {BASE_API_URL} from "../config";
import DOMPurify from "dompurify";

const fetchAboutPage = async () => {
  return await fetch(`${BASE_API_URL}/meta/about`)
    .then(response => response.json());
};

export const About = () => {
  const [isLoading, setIsLoading] = useState(true);
  const [aboutInfo, setAboutInfo] = useState<IPageInfo>(null!);
  const sanitizedData = () => ({
    __html: DOMPurify.sanitize(aboutInfo.content)
  });
  
  const fetchData = () => {
    fetchAboutPage().then(data => setAboutInfo(data));
  };
  
  useEffect(() => {
    if (aboutInfo) {
      setIsLoading(false);
    } else {
      fetchData();
    }
  }, [aboutInfo]);

  return (
    <div>
      <h2>About</h2>
      {isLoading ?
        <p>Loading...</p> :
        <>
          <div dangerouslySetInnerHTML={sanitizedData()}></div>
        </>
      }
    </div>
  );
};