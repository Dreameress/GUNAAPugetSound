import React from "react";
import cn from "classnames";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTwitter } from "@fortawesome/free-brands-svg-icons";
import { faInstagram } from "@fortawesome/free-brands-svg-icons";
import { faFacebook } from "@fortawesome/free-brands-svg-icons";
import { faEnvelope } from "@fortawesome/free-solid-svg-icons";
import { faDonate } from "@fortawesome/free-solid-svg-icons";

const FooterListItem = ({ facebook, instagram, twitter, email, donate, text, link }) => (
  <li className="footer-list-item">
    <a href={link} target="_blank">
      {(() => {
        if (facebook)
          return <FontAwesomeIcon icon={faFacebook} style={{ fontSize: 36 }} />;
        else if (instagram)
          return <FontAwesomeIcon icon={faInstagram} style={{ fontSize: 36 }} />;
        else if (twitter)
          return <FontAwesomeIcon icon={faTwitter} style={{ fontSize: 36 }} />;
        else if (email)
          return <FontAwesomeIcon icon={faEnvelope} style={{ fontSize: 36 }} />;
        else if (donate)
          return <FontAwesomeIcon icon={faDonate} style={{ fontSize: 36 }} />;
      })()}

    </a>
    <a href={link}>{text}</a>
  </li>
);

export default FooterListItem;
