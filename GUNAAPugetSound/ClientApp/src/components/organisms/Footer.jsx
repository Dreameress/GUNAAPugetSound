import React from "react";
import  FooterListItem from "./../molecules/FooterListItem";

const Footer = () => (
  <div className="footer-basic">
    <footer style={{ textAlign: "center" }}>
      <ul className="footer-list">
        <FooterListItem email text="Email" link="mailto:gunaapugetsound@hotmail.com" />
        <FooterListItem facebook text="Facebook" link="https://www.facebook.com/GUNAAPugetSoundSeattle/"   />
        <FooterListItem instagram text="Instagram" link="https://www.instagram.com/gunaapugetsoundseattle/" />
        <FooterListItem twitter text="Twitter" link="https://www.twitter.com/GunaaPuget/" />
        <FooterListItem donate text="Donate" link="https://www.paypal.com/paypalme/gunaaseattlealumni" />
      </ul>
      <p className="copyright">
        Grambling State University - Puget Sound is a registered 501(c)3
        nonprofit. Your donations are tax deductible.
      </p>
      <p style={{color: '#ff91a4', fontVariant:'all-small-caps'}}>&copy; Copyright {new Date().getFullYear()} Digiophile</p>
    </footer>
  </div>
);

export default Footer;
