import React, {useEffect, useState} from "react";
import {IPageInfo} from "../models/IPageInfo";
import DOMPurify from "dompurify";

const fetchAboutPage = async () => {
  return await fetch(`/api/v1/Meta/About`)
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